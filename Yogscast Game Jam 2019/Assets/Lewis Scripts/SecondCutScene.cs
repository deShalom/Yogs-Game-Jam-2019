using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCutScene : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Vector3 endMarker;

    // Movement speed in units per second.
    public float speed = 0.1F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Bool for jolts
    private bool rightJolt, leftJolt, startedRightJolt, startedLeftJolt;

    // Amount of Jolt
    public float joltAmount = 3f;

    //current rotate and wanted rotate
    private Quaternion getRotate, wantedRotate;


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

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
    }

    // Move to the target end position.
    void Update()
    {
        timeLeft += Time.deltaTime;
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker, fractionOfJourney);

        if (timeLeft > 1f)
        {
            timeLeft = 0f;
            if (rightJolt)
            {
                getRotate = gameObject.transform.rotation;
                startedRightJolt = true;
                wantedRotate.z = 50f;
                rightJolt = false;
                print("im in right");
            }else if (leftJolt)
            {
                getRotate = gameObject.transform.rotation;
                startedLeftJolt = true;
                wantedRotate.z = -50f;
                leftJolt = false;
                print("im in left");
            }

        }
        if (startedRightJolt)
        {
            transform.rotation = Quaternion.Lerp(getRotate, wantedRotate, Time.time * speed);
            startedRightJolt = false;
            leftJolt = true;
            print("im moving right");
        }
        if (startedLeftJolt)
        {
            transform.rotation = Quaternion.Lerp(getRotate, wantedRotate, Time.time * speed);
            startedLeftJolt = false;
            rightJolt = true;
            print("im moving left");
        }

    }

}
