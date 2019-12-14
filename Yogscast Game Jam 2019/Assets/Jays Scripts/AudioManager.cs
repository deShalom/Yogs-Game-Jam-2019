using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //Variables
    public Slider aSlider, mSlider;

    //Methods

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("mVolume");
    }
    private void Update()
    {
        //Tester
        PlayerPrefs.SetFloat("mVolume", aSlider.value);
        Volume();
    }

    public void Volume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("mVolume");
    }
}
//All code written by Jay Underwood (deShalom).
