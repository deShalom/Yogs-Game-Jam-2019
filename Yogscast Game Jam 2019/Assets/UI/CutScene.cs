using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [SerializeField]
    private float speedX, speedY, speedZ, waitTime;
    [SerializeField]
    private GameObject objtxt;
    private Text txtplaygame;
    public bool completedMoving, timehasbeenset;
    private float timer;
    Color lerpedColor;
    // Start is called before the first frame update
    void Start()
    {
        completedMoving = false;
        timehasbeenset = false;
        txtplaygame = objtxt.GetComponent<Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        txtplaygame.color = lerpedColor;
        timer += Time.deltaTime;

        //
        if (transform.localScale.x < 1f)
        {
            transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 2, Time.deltaTime * 1.2f);
        }
        if((transform.localScale.x >= 1f) & (transform.localRotation.z != 0))
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,0), Time.deltaTime * 10f);
            completedMoving = true;
            if (!timehasbeenset)
            {
                timer = 0f;
                timehasbeenset = true;
            }


        }
        if ((completedMoving) & (timer > waitTime))
        {
            objtxt.SetActive(true);
            lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        }

    }
}
