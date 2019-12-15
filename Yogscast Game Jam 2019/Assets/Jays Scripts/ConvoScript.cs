using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvoScript : MonoBehaviour
{
    public string[] conversationOptions;
    private string currentMainText;
    //[Header("UI Question Buttons")]
    public Button option1, option2;

    public float audioSourceVolume;

    //[Header("Animators")]
    //Leg and Arm animators
    public Animator legAnimator, armAnimator, doorAnimator;

    //[Header("UI Text")]
    public Text currentDisplayedText, questionOption1, questionOption2, diceText, noPresentsLeft;
    public GameObject questionsPanel, dice;

    private DayCycles dayCycles;

    [SerializeField] public AudioClip[] s_Slap, s_Kick, s_Gift;
    private AudioSource audioSource;



    //Prefabs
    public GameObject launchPoint, holdingPoint;
    [Header("Prefabs")]
    public GameObject[] presents;
    public GameObject[] weapons;
    public int testWeapon;

    private bool conversationIsResolved = false, waitingForDiceRoll = false, conversationOnGoing = false;
    private float diceTimer;
    public bool diceHasRolled = false;

    string kickAnimation;

    // Update is called once per frame
    void Update()
    {
        if (waitingForDiceRoll && diceHasRolled)
        {
            waitingForDiceRoll = false;
            diceHasRolled = false;
            Debug.Log("rolled dice");
            diceText.gameObject.SetActive(true);
            //Time that the dice remains on screen
            diceTimer = 1f;
            //Play sound
            PlaySound(s_Kick[Random.Range(0, s_Kick.Length)]);
            //Play animation
            legAnimator.SetTrigger(kickAnimation);
        }
        if(diceTimer > 0f)
        {
            diceTimer -= Time.deltaTime;
        }
        else if(diceTimer != 0f)
        {
            diceTimer = 0f;
            diceText.gameObject.SetActive(false);
            dice.SetActive(false);
        }

        //Code for click raycasts (give button / door handle)
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.tag == "GiveButton")
                {
                    hit.transform.gameObject.GetComponent<Animator>().SetTrigger("button_press");
                    Gift();
                }
                if(hit.transform.tag == "DoorHandle")
                {
                    if (!conversationOnGoing)
                    {
                        StartNewConversation();
                    }
                }
            }
        }
    }

    private void Start()
    {
        currentMainText = "some texttxtxtxttxtxttxttxtxtxtxttxt";
        StartNewConversation();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSourceVolume;
        dayCycles = GetComponent<DayCycles>();
        UpdatePresentText();
        Instantiate(weapons[testWeapon], holdingPoint.transform);
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
        doorAnimator.SetTrigger("door_open");
        conversationOnGoing = true;
    }

    //Use whenever action takes place- this will update what the character says or decide when a conversation is over
    private void CycleConversation()
    {
        if (conversationIsResolved /*&& no of viewings left is != 0*/)
        {
            dayCycles.ViewerCycle();
            conversationIsResolved = false;
            conversationOnGoing = false;
            doorAnimator.SetTrigger("door_close");
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

        //Kick logic
        //Roll d20 for damage
        var newRoll = RollD20();
        diceText.text = newRoll.ToString();
        if(newRoll > 15)
        {
            kickAnimation = "kick_2";
        }
        else
        {
            kickAnimation = "kick_1";
        }

        //Resolve conversation
        conversationIsResolved = true;
        CycleConversation();
    }

    public void SlapPerson()
    {
        PlaySound(s_Slap[Random.Range(0, s_Slap.Length)]);
        //Slap logic
        var newRanNum = Random.Range(0,3);
        switch (newRanNum)
        {
            case 0:
                armAnimator.SetTrigger("slap_1");
                break;
            case 1:
                armAnimator.SetTrigger("slap_2");
                break;
            case 2:
                armAnimator.SetTrigger("slap_3");
                break;
        }

        CycleConversation();
    }

    public void Gift()
    {
        if (dayCycles.nOfPresents > 0)
        {
            //PlaySound(s_Gift[Random.Range(0, s_Gift.Length)]);
            LaunchPresent();
            //Gift logic
            armAnimator.SetTrigger("throw");
            //Decrement available presents
            dayCycles.nOfPresents--;
            UpdatePresentText();
        }
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
        dice.SetActive(true);
        dice.GetComponent<Animation>().Play();
        waitingForDiceRoll = true;
        return Random.Range(1, 21);
    }

    private void UpdatePresentText()
    {
        noPresentsLeft.text = "Number of Presents Left: "+dayCycles.nOfPresents.ToString();
    }

    private void LaunchPresent()
    {
        var newPresent = Instantiate(presents[Random.Range(0,presents.Length)],launchPoint.transform);
        newPresent.GetComponent<Rigidbody>().AddForce(new Vector3(0f,100f,1000f));
        
    }
}