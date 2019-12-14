using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomSplash : MonoBehaviour
{
    public bool splashscreenFinished;
    IEnumerator Start()
    {
        splashscreenFinished = false;
        Debug.Log("Showing splash screen");
        SplashScreen.Begin();
        while (!SplashScreen.isFinished)
        {
            SplashScreen.Draw();
            yield return null;
        }
        Debug.Log("Finished showing splash screen");
        splashscreenFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
