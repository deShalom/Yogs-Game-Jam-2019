using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCutScene : MonoBehaviour
{
    [SerializeField]
    private GameObject objtxt, audioMenu;

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Vector3 endMarker;
    public float makeMePoint2LowerThanEndMaker;

    // Movement speed in units per second.
    public float speed = 0.01F;
    public float rotateBackSpeed = 10f;
    public float timeForSteps = 0.9f;
    

    // Time when the movement started.
    private float startTime;
    private float timerText;

    // Total distance between the markers.
    private float journeyLength;

    // Bool for jolts
    private bool rightJolt, leftJolt, startedRightJolt, startedLeftJolt, firstJolt, lastJolt;

    private bool textshowing, startTextTime, startTextTimeStarted;

    private float joltAmount;

    private Quaternion currentRotate, endRotate;

    private Text txtplaygame;
    Color lerpedColor;

    public SceneLoader sl;
    private JsCommonCode am;


    //timer
    private float timeLeft;
    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        //timer for rotate
        timeLeft = Time.deltaTime;

        rightJolt = true;
        leftJolt = false;
        startedLeftJolt = false;
        startedRightJolt = false;
        firstJolt = true;
        lastJolt = false;
        textshowing = false;
        startTextTime = false;
        startTextTimeStarted = false;
        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
        txtplaygame = objtxt.GetComponent<Text>();
        am = audioMenu.GetComponent<JsCommonCode>();

    }

    // Move to the target end position.
    void Update()
    {
        txtplaygame.color = lerpedColor;
        timeLeft += Time.deltaTime;
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker, fractionOfJourney);

        if (timeLeft > timeForSteps)
        {
            timeLeft = 0f;
            if (rightJolt)
            {
                startedRightJolt = true;
                rightJolt = false;
            }else if (leftJolt)
            {
                startedLeftJolt = true;
                leftJolt = false;
            }

        }

        if (firstJolt)
        {
            joltAmount = 2f;
            firstJolt = false;
        }
        if ((startedRightJolt) & (!lastJolt))
        {
            //transform.rotation = Quaternion.Lerp(getRotate, wantedRotate, speed);
            transform.Rotate(0f, 0f, joltAmount);
            startedRightJolt = false;
            leftJolt = true;
            print("im moving right");
            firstJolt = false;
            joltAmount = 4f;
            am.soundEffect(0);
        }
        if ((startedLeftJolt) & (!lastJolt))
        {
            //transform.rotation = Quaternion.Lerp(getRotate, wantedRotate, speed);
            transform.Rotate(0f,0f,-joltAmount);
            startedLeftJolt = false;
            rightJolt = true;
            print("im moving left");
            am.soundEffect(1);

        }

        if ((transform.position.z > makeMePoint2LowerThanEndMaker) & (!lastJolt))
        {
            lastJolt = true;
            currentRotate = gameObject.transform.rotation;
            endRotate = new Quaternion(0f, 0f, 0f, 1);
        }

        if (lastJolt)
        {
            transform.rotation = Quaternion.Lerp(currentRotate, endRotate, Time.time * rotateBackSpeed);
            if (!startTextTimeStarted)
            {
                startTextTime = true;
                startTextTimeStarted = true;
                timerText = 0f;
            }
            
        }
        if (startTextTime)
        {
            timerText += Time.deltaTime;
        }
        

        if ((lastJolt) & (timerText > 2f))
        {
            objtxt.SetActive(true);
            lerpedColor = Color.Lerp(Color.black, Color.white, Mathf.PingPong(Time.time, 1));
            textshowing = true;
        }

        if ((Input.GetMouseButtonDown(0)) & (textshowing))
            sl.loadScene("Dialogue");
    }

}
