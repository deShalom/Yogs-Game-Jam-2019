using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycles : MonoBehaviour
{
    public int Days = 12;
    public int nOfViewers = 10;
    private bool viewingDone;

    void Start()
    {
        ViewerCycle();
    }

    void Update()
    {
        
    }

    void ViewerCycle()
    {
        while(nOfViewers >= 1)
        {
            //Insert code here to execute viewer.
            LaunchViewing();
            if (nOfViewers == 0)
            {
                break;
            }
        }
    }

    void DayComplete()
    {
        Days = Days - 1;
        nOfViewers = nOfViewers++;
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
    }
}
//All code written by Jay Underwood (deShalom).
