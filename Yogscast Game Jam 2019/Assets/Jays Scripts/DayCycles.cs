using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycles : MonoBehaviour
{
    public int Days = 12;
    public static int statDays;
    public int nOfViewers = 10;
    public int nOfPresents = 6;
    public int nOfViewersCounter;
    private bool viewingDone;

    void Start()
    {
        ViewerCycle();
    }

    void Update()
    {
        statDays = Days;
    }

    public void ViewerCycle()
    {
        while(nOfViewersCounter >= 1)
        {
            //Insert code here to execute viewer.
            LaunchViewing();
            if (nOfViewers == 0)
            {
                DayComplete();
                break;
            }
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