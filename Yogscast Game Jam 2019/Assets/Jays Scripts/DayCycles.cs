using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycles : MonoBehaviour
{
    public static int Days = 12;
    public int nOfViewers = 10;
    public int nOfPresents = 6;
    public int nOfViewersCounter;
    private bool viewingDone;

    public ConvoScript convoScript;

    void Start()
    {
        ViewerCycle();
        //convoScript = gameObject.GetComponent<ConvoScript>();
    }

    void Update()
    {
    }

    public void ViewerCycle()
    {
        if(nOfViewersCounter >= 1)
        {
            //Insert code here to execute viewer.
            LaunchViewing();

        }
        else if (nOfViewers == 0)
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
        ViewerCycle();

        if (Days == 0)
        {
            //Execute game over code here.
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