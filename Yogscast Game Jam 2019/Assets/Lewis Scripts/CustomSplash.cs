using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CustomSplash : MonoBehaviour
{
    public bool splashscreenFinished;
    [SerializeField]
    private GameObject btnStart, audioMenu;
    private bool hasMenuEnabled;


    IEnumerator Start()
    {
        
        hasMenuEnabled = false;
        splashscreenFinished = false;
        SplashScreen.Begin();
        while (!SplashScreen.isFinished)
        {
            SplashScreen.Draw();
            yield return null;
        }
        splashscreenFinished = true;
        hasMenuEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((splashscreenFinished) & (hasMenuEnabled))
        {
            print("do i get here");
            btnStart.GetComponent<Button>().enabled = true;
            audioMenu.SetActive(true);

        }
    }
}
