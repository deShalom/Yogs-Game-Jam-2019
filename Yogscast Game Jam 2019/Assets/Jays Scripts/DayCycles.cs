using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCycles : MonoBehaviour
{
    public static int Days = 2;
    public static int nOfViewers = 10;
    public static int nOfPresents = 6;
    public int nOfViewersCounter;
    private bool viewingDone, endDay = false;
    private float timer;

    public ConvoScript convoScript;
    public JsCommonCode cc;

    void Start()
    {
        ViewerCycle();
        //convoScript = gameObject.GetComponent<ConvoScript>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer != 0)
        {
            timer = 0f;
            SceneManager.LoadScene("TransitionScene");
        }
    }

    public void ViewerCycle()
    {
        if(nOfViewersCounter >= 1)
        {
            //Insert code here to execute viewer.
            LaunchViewing();
            nOfViewersCounter--;
        }
        else if (nOfViewersCounter == 0)
        {
            DayComplete();
        }
    }

    void DayComplete()
    {
        Days = Days - 1;
        nOfViewers = nOfViewers++;
        nOfPresents = nOfPresents++;
        nOfViewersCounter = nOfViewers;
        //ViewerCycle();

        if (Days == 0)
        {
            //Execute game over code here.
            cc.loadScene("Game Over Screen");
        }
        else
        {
            endDay = true;
            timer = 2f;
        }
    }

    void LaunchViewing()
    {
        //Inster code here to start a viewing.
        convoScript.StartNewConversation();

        if (viewingDone == true)
        {
            ViewingComplete();
            viewingDone = false;
        }
    }

    void ViewingComplete()
    {
        //Inster code here to complete a viewing.
        ViewerCycle();
    }
}
//All code written by Jay Underwood (deShalom).