using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JsCommonCode : MonoBehaviour
{
    //Variables
    public string scnName;
    public Slider eSlider, mSlider;
    public AudioSource music, sEffects, sEffects2;
    public AudioClip[] SoundtrackClips, SoundEffectClips;

    //YogsGameJam Variables
    public GameObject AudioMenu;
    public Button ExitGame, CloseMenu;

    //Methods
    private void Start()
    {
        music.volume = PlayerPrefs.GetFloat("mVolume");
        sEffects.volume = PlayerPrefs.GetFloat("eVolume");
        sEffects2.volume = PlayerPrefs.GetFloat("eVolume");
    }
    private void Update()
    {
        //Tester
        PlayerPrefs.SetFloat("mVolume", mSlider.value);
        PlayerPrefs.SetFloat("eVolume", eSlider.value);
        Volume();
        openMenuKey(AudioMenu);

        //Check against Lewis's splash screen bool
    }

    //Audio Control
    public void Volume()
    {
        music.volume = PlayerPrefs.GetFloat("mVolume");
        sEffects.volume = PlayerPrefs.GetFloat("eVolume");
        sEffects2.volume = PlayerPrefs.GetFloat("eVolume");
    }

    //Soundtrack
    public void soundTrack()
    {
        if (!music.isPlaying)
        {
            int randomClip = Random.Range(0, SoundtrackClips.Length);
            music.clip = SoundtrackClips[randomClip];
            music.Play();
        }
    }

    //Sound Effects Player
    public void soundEffect(int eClip)
    {
        sEffects.clip = SoundEffectClips[eClip];
    }

    //Sound Effects Player
    void soundEffect(int eClip, int eClip2)
    {
        sEffects.clip = SoundEffectClips[eClip];
        sEffects2.clip = SoundEffectClips[eClip2];
    }

    //Scene Loader
    public void loadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    //Exit Game
    public void exitGame()
    {
        Application.Quit();
    }

    //Menu Opening
    public void openMenuKey(GameObject menu)
    {
        if (Input.GetKeyDown("escape") && menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else if (Input.GetKeyDown("escape") && menu.activeInHierarchy == false)
        {
            menu.SetActive(true);
        }
    }

    //YogsGameJam Methods
    public void closeMenu()
    {
        AudioMenu.SetActive(false);
    }
    public void openMenu()
    {
        AudioMenu.SetActive(true);
    }
}
//All code written by Jay Underwood (deShalom).
