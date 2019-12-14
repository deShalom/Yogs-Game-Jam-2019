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
    public AudioSource music, sEffects;
    public AudioClip[] SoundtrackClips;
    public bool menuOpen, menuClosed;

    //YogsGameJam Variables
    public GameObject AudioMenu;
    public Button ExitGame, CloseMenu;

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
        openMenuKey(AudioMenu);

        //Check against Lewis's splash screen bool
        soundTrack();
    }

    //Audio Control
    public void Volume()
    {
        music.volume = PlayerPrefs.GetFloat("mVolume");
        sEffects.volume = PlayerPrefs.GetFloat("eVolume");
    }

    //Soundtrack
    void soundTrack()
    {
        if (!music.isPlaying)
        {
            int randomClip = Random.Range(0, SoundtrackClips.Length);
            music.clip = SoundtrackClips[randomClip];
            music.Play();
        }
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
