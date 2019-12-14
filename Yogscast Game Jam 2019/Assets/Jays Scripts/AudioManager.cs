using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //Variables
    public Slider eSlider, mSlider;
    public AudioSource music, sEffects;

    //Methods

    private void Start()
    {
        music.volume = PlayerPrefs.GetFloat("mVolume");
        sEffects.volume = PlayerPrefs.GetFloat("eVolume");
    }
    private void Update()
    {
        //Tester
        PlayerPrefs.SetFloat("mVolume", mSlider.value);
        PlayerPrefs.SetFloat("eVolume", eSlider.value);
        Volume();
    }

    public void Volume()
    {
        music.volume = PlayerPrefs.GetFloat("mVolume");
        sEffects.volume = PlayerPrefs.GetFloat("eVolume");
    }
}
//All code written by Jay Underwood (deShalom).
