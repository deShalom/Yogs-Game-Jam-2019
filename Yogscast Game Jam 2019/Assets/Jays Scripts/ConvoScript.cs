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
    public Text nameText;
    public GameObject calcpoints;
    public float audioSourceVolume;

    //[Header("Animators")]
    //Leg and Arm animators
    public Animator legAnimator, armAnimator, doorAnimator;

    //[Header("UI Text")]
    public Text currentDisplayedText, questionOption1, questionOption2, diceText, noPresentsLeft;
    public GameObject questionsPanel, dice;

    private DayCycles dayCycles;
    public DialogueManager dialogueManager;
    public CalculatePoints calculatePoints;
    public JsCommonCode jsCommonCode;

    [SerializeField] public AudioClip[] s_Slap, s_Kick, s_Gift;
    private AudioSource audioSource;


    Animator animatorOfCurrentPerson;
    GameObject currentPerson;

    //Prefabs
    public GameObject launchPoint, holdingPoint, personSpawner;
    [Header("Prefabs")]
    public GameObject[] presents;
    public GameObject[] weapons;
    public GameObject[] characters;
    public int testWeapon, personID;

    private bool conversationIsResolved = false, waitingForDiceRoll = false, conversationOnGoing = false;
    private float diceTimer, timer;
    public bool diceHasRolled = false;

    string kickAnimation;

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = jsCommonCode.sEffects.volume;

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

        if(timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else if(timer != 0f)
        {
            timer = 0f;
            NewViewingReady();
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
                        dayCycles.ViewerCycle();
                    }
                }
            }
        }
    }

    private void Start()
    {
        QuestionsToggle();
        currentMainText = "some texttxtxtxttxtxttxttxtxtxtxttxt";
        //StartNewConversation();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = jsCommonCode.sEffects.volume;
        dayCycles = GetComponent<DayCycles>();
        UpdatePresentText();
        jsCommonCode.soundTrack();
        //Instantiate(weapons[testWeapon], holdingPoint.transform);
    }

    public void StartNewConversation()
    {
        conversationIsResolved = false;
        //Show character
        //Set text and convo options
        //currentMainText = text from file;
        dialogueManager.GetReason();
        currentMainText = dialogueManager.reasonTxt;
        dialogueManager.GetQuestions();
        questionOption1.text = dialogueManager.questions[0];
        questionOption2.text = dialogueManager.questions[1];
        currentDisplayedText.text = currentMainText;
        //
        personID = Random.Range(0, characters.Length);
        currentPerson = Instantiate(characters[personID], personSpawner.transform);

        QuestionsToggle();

        animatorOfCurrentPerson = currentPerson.GetComponentInChildren<Animator>();
        doorAnimator.SetTrigger("door_open");
        conversationOnGoing = true;
        switch (personID)
        {
            case 0:
                nameText.text = "Duncan";
                break;
            case 1:
                nameText.text = "Lewis";

                break;
            case 2:
                nameText.text = "Simon";

                break;
            case 3:
                nameText.text = "Sips";

                break;
            case 4:
                nameText.text = "Spiff";

                break;
        }
    }

    //Use whenever action takes place- this will update what the character says or decide when a conversation is over
    private void CycleConversation()
    {
        if (conversationIsResolved /*&& no of viewings left is != 0*/)
        {
            Debug.Log(dayCycles.nOfViewersCounter);
            if (dayCycles.nOfViewersCounter != 0)
            {
                calcpoints.GetComponent<CalculatePoints>().UpdatePoints();
                //dayCycles.ViewerCycle();
                conversationIsResolved = false;
                conversationOnGoing = false;
                doorAnimator.SetTrigger("door_close");
                //Set timer for next viewing
                timer = 2f;
            }
            else
            {
                Debug.Log("day cycle");
                dayCycles.ViewerCycle();
            }
        }
        else
        {
            //Update conversation
            //dialogueManager.GetAnswers();
            currentMainText = dialogueManager.answerTxt;
            dialogueManager.GetQuestions();
            questionOption1.text = dialogueManager.questions[0];
            questionOption2.text = dialogueManager.questions[1];
            currentDisplayedText.text = currentMainText;
        }

    }

    void NewViewingReady()
    {
        doorAnimator.SetTrigger("door_knock");
        jsCommonCode.soundEffect(1);
    }

    public void KickPerson()
    {
        if (diceTimer == 0 && conversationOnGoing)
        {
            //Kick logic
            //Roll d20 for damage
            var newRoll = RollD20();
            if (CalculatePoints.kickBuy)
            {
                newRoll += 5;
            }
            diceText.text = newRoll.ToString();
            if (newRoll > 20)
            {
                kickAnimation = "kick_2";
            }
            else
            {
                kickAnimation = "kick_1";
            }
        }
    }

    public void KickingFinished(int crit)
    {
        //Resolve conversation
        calcpoints.GetComponent<CalculatePoints>().Kicked();
        conversationIsResolved = true;
        if (crit == 1)
        {
            currentPerson.GetComponent<Rigidbody>().AddForce(0f, 200f, 1000f);
        }
        else
        {
            currentPerson.GetComponent<Rigidbody>().AddForce(0f, 200f, 500);
        }
        CycleConversation();
    }

    public void SlapPerson()
    {
        if (conversationOnGoing)
        {
            PlaySound(s_Slap[Random.Range(0, s_Slap.Length)]);
            //Slap logic
            var newRanNum = Random.Range(0, 3);
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

            animatorOfCurrentPerson.SetTrigger("hit");

            CycleConversation();
        }
    }

    public void Gift()
    {
        Debug.Log("throw gift");
        if (conversationOnGoing)
        {
            //PlaySound(s_Gift[Random.Range(0, s_Gift.Length)]);
            //LaunchPresent();
            //Gift logic
            
            if (DayCycles.nOfPresents > 0)
            {
                //PlaySound(s_Gift[Random.Range(0, s_Gift.Length)]);
                LaunchPresent();
                //Gift logic
                armAnimator.SetTrigger("throw");
                //Decrement available presents
                DayCycles.nOfPresents--;
                UpdatePresentText();
                calcpoints.GetComponent<CalculatePoints>().Gifted();
            }
            //Resolve conversation
            conversationIsResolved = true;
            CycleConversation();
        }
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
            dialogueManager.GetAnswers(0);
        }
        if(question == 2)
        {
            Debug.Log("Asked question 2");
            dialogueManager.GetAnswers(1);
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
        jsCommonCode.soundEffect(0);
        return Random.Range(1, 21);
    }

    private void UpdatePresentText()
    {
        noPresentsLeft.text = "Number of Presents Left: "+DayCycles.nOfPresents.ToString();
    }

    private void LaunchPresent()
    {
        var newPresent = Instantiate(presents[Random.Range(0,presents.Length)],launchPoint.transform);
        newPresent.GetComponent<Rigidbody>().AddForce(new Vector3(0f,100f,1000f));
        
    }
}