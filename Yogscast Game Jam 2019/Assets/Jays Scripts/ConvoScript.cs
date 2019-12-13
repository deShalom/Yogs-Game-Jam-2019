using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvoScript : MonoBehaviour
{
    public string[] conversationOptions;
    public Button option1, option2;


    public Text currentDisplayedText, questionOption1, questionOption2;
    public GameObject questionsPanel;



    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        StartNewConversation();
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

    }

    public void SlapPerson()
    {

    }

    public void Gift()
    {

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
    
}