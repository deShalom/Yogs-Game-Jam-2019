using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvoScript : MonoBehaviour
{
    public string[] conversationOptions;
    public Button option1, option2;

    public float audioSourceVolume;


    public Text currentDisplayedText, questionOption1, questionOption2;
    public GameObject questionsPanel;

    [SerializeField] public AudioClip[] s_Slap, s_Kick, s_Gift;
    private AudioSource audioSource;



    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        StartNewConversation();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSourceVolume;
    }

    public void StartNewConversation()
    {
        //Show character
        //Set text and convo options
        questionOption1.text = conversationOptions[0];
        questionOption2.text = conversationOptions[1];
        //
    }

    public void KickPerson()
    {
        PlaySound(s_Kick[Random.Range(0, s_Kick.Length)]);
        //Kick logic
    }

    public void SlapPerson()
    {
        PlaySound(s_Slap[Random.Range(0, s_Slap.Length)]);
        //Slap logic
    }

    public void Gift()
    {
        PlaySound(s_Gift[Random.Range(0, s_Gift.Length)]);
        //Gift logic
    }

    public void QuestionsToggle()
    {
        if (questionsPanel.activeInHierarchy)
        {
            questionsPanel.SetActive(false);
        }
        else
        {
            questionsPanel.SetActive(true);
        }
    }

    public void Question(int question)
    {
        if (question == 1)
        {
            Debug.Log("Asked question 1");
        }
        if(question == 2)
        {
            Debug.Log("Asked question 2");
        }

        QuestionsToggle();

    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    
}