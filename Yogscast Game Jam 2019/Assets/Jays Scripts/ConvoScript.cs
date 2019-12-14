using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvoScript : MonoBehaviour
{
    public string[] conversationOptions;
    private string currentMainText;
    public Button option1, option2;

    public float audioSourceVolume;

    public Text currentDisplayedText, questionOption1, questionOption2;
    public GameObject questionsPanel;

    [SerializeField] public AudioClip[] s_Slap, s_Kick, s_Gift;
    private AudioSource audioSource;

    private bool conversationIsResolved = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        currentMainText = "some texttxtxtxttxtxttxttxtxtxtxttxt";
        StartNewConversation();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSourceVolume;
    }

    public void StartNewConversation()
    {
        conversationIsResolved = false;
        //Show character
        //Set text and convo options
        //currentMainText = text from file;
        questionOption1.text = conversationOptions[0];
        questionOption2.text = conversationOptions[1];
        currentDisplayedText.text = currentMainText;
        //
    }

    //Use whenever action takes place- this will update what the character says or decide when a conversation is over
    private void CycleConversation()
    {
        if (conversationIsResolved /*&& no of viewings left is != 0*/)
        {
            StartNewConversation();
        }
        else
        {
            //Update conversation
            questionOption1.text = conversationOptions[0];
            questionOption2.text = conversationOptions[1];
            currentDisplayedText.text = currentMainText;
        }
    }

    public void KickPerson()
    {
        PlaySound(s_Kick[Random.Range(0, s_Kick.Length)]);
        //Kick logic
        //Roll d20 for damage
        var newRoll = RollD20();


        //Resolve conversation
        conversationIsResolved = true;
        CycleConversation();
    }

    public void SlapPerson()
    {
        PlaySound(s_Slap[Random.Range(0, s_Slap.Length)]);
        //Slap logic

        CycleConversation();
    }

    public void Gift()
    {
        PlaySound(s_Gift[Random.Range(0, s_Gift.Length)]);
        //Gift logic

        //Resolve conversation
        conversationIsResolved = true;
        CycleConversation();
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
        CycleConversation();
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    private int RollD20()
    {
        //Run animation
        return Random.Range(1, 20);
    }
}