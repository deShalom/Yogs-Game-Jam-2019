using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //Variables
    public Slider eSlider, mSlider;
    public AudioSource music, sEffects;
    public AudioClip[] SoundtrackClips;

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
        soundTrack();
    }

    public void Volume()
    {
        music.volume = PlayerPrefs.GetFloat("mVolume");
        sEffects.volume = PlayerPrefs.GetFloat("eVolume");
    }

    void soundTrack()
    {
        if (!music.isPlaying)
        {
            int randomClip = Random.Range(0, SoundtrackClips.Length);
            music.clip = SoundtrackClips[randomClip];
            music.Play();
        }
    }
}
//All code written by Jay Underwood (deShalom).
