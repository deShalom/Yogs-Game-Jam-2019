using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public int charAlignment, charID, reasonID;
    public string contents, reasonTxt, answerContents, answerTxt;
    public string[] reason, questions, answers;
    public int[] answerID;
    public TextAsset[] ReasonFile, AnswerFile, SlapFile, KickFile;
    public bool isLying;
    //public Text

    public StreamReader txtFile, answerFile;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

      
    public void GetReason()
    {
        //Setup of alignment and generation of Reason
        charAlignment = Random.Range(0, 3);
        charID = Random.Range(0, 5);
        txtFile = new StreamReader(Application.dataPath + "/Dialog Resources/" + ReasonFile[charAlignment].name + ".txt");
        contents = txtFile.ReadToEnd();
        txtFile.Close();
        
        reason = contents.Split("\n"[0]);
        reasonID = Random.Range(0, reason.Length);
        reasonTxt = reason[reasonID];
        //Deciding if they're lying depending on chance from alignment.
        if (charAlignment == 0)
        {
            int chanceRange = 50;
            int rng = Random.Range(0, 101);

            if(rng <= chanceRange)
            {
                isLying = true;
            }
                } else if (charAlignment == 1)
        {
            int chanceRange = 25;
            int rng = Random.Range(0, 101);

            if(rng <= chanceRange)
            {
                isLying = true;
            }
        }
        
    }

    public void GetQuestions()
    {
        switch (charAlignment)
        {
            case 0:
                switch (reasonID)
                {
                    case 0:
                        questions[0] = "What’s the brand of the food?";                        
                        questions[1] = "What breed of dog was it?";
                        if (!isLying)
                        {
                            answerID[0] = 0;
                            answerID[1] = 2;
                        }else if (isLying)
                        {
                            answerID[0] = 1;
                            answerID[1] = 3;
                        }
                        break;
                    case 1:
                        questions[0] = "What door number is your neighbour?";
                        questions[1] = "What’s your neighbour’s name?";
                        if (!isLying)
                        {
                            answerID[0] = 4;
                            answerID[1] = 6;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 5;
                            answerID[1] = 7;
                        }
                        break;
                    case 2:
                        questions[0] = "Where do you work at?";
                        questions[1] = "What were they talking about?";
                        if (!isLying)
                        {
                            answerID[0] = 8;
                            answerID[1] = 10;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 9;
                            answerID[1] = 11;
                        }
                        break;
                    case 3:
                        questions[0] = "What kind of dishes were they?";
                        questions[1] = "That’s gross, dude. Do your dishes";
                        if (!isLying)
                        {
                            answerID[0] = 12;
                            answerID[1] = 14;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 13;
                            answerID[1] = 15;
                        }
                        break;
                    case 4:
                        questions[0] = "Just the scraps? You couldn’t spare a little more?";
                        questions[1] = "What did they say after?";
                        if (!isLying)
                        {
                            answerID[0] = 16;
                            answerID[1] = 18;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 17;
                            answerID[1] = 19;
                        }
                        break;
                }
                break;

            case 1:
                switch (reasonID)
                {
                    case 0:
                        questions[0] = "What kind of trash was it?";
                        questions[1] = "Where did you put it?";
                        if (!isLying)
                        {
                            answerID[0] = 0;
                            answerID[1] = 2;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 1;
                            answerID[1] = 3;
                        }
                        break;
                    case 1:
                        questions[0] = "What did they reply?";
                        questions[1] = "Who was it?";
                        if (!isLying)
                        {
                            answerID[0] = 4;
                            answerID[1] = 6;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 5;
                            answerID[1] = 7;
                        }
                        break;
                    case 2:
                        questions[0] = "At what restaurant?";
                        questions[1] = "What did she serve to you?";
                        if (!isLying)
                        {
                            answerID[0] = 8;
                            answerID[1] = 10;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 9;
                            answerID[1] = 11;
                        }
                        break;
                    case 3:
                        questions[0] = "How did they react?";
                        questions[1] = "What did you say to them?";
                        if (!isLying)
                        {
                            answerID[0] = 12;
                            answerID[1] = 14;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 13;
                            answerID[1] = 15;
                        }
                        break;
                    case 4:
                        questions[0] = "What was that friend’s name?";
                        questions[1] = "What did you do?";
                        if (!isLying)
                        {
                            answerID[0] = 16;
                            answerID[1] = 18;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 17;
                            answerID[1] = 19;
                        }
                        break;
                }
                break;

            case 2:
                switch (reasonID)
                {
                    case 0:
                        questions[0] = "What street was it?";
                        questions[1] = "What was her name?";
                        if (!isLying)
                        {
                            answerID[0] = 0;
                            answerID[1] = 2;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 1;
                            answerID[1] = 3;
                        }
                        break;
                    case 1:
                        questions[0] = "What's the name of the shelter?";
                        questions[1] = "When did you do it?";
                        if (!isLying)
                        {
                            answerID[0] = 4;
                            answerID[1] = 6;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 5;
                            answerID[1] = 7;
                        }
                        break;
                    case 2:
                        questions[0] = "What is the name of the charity?";
                        questions[1] = "How much did you donate?";
                        if (!isLying)
                        {
                            answerID[0] = 8;
                            answerID[1] = 10;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 9;
                            answerID[1] = 11;
                        }
                        break;
                    case 3:
                        questions[0] = "What organisation did you donate to?";
                        questions[1] = "Can I see your Donor Card?";
                        if (!isLying)
                        {
                            answerID[0] = 12;
                            answerID[1] = 14;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 13;
                            answerID[1] = 15;
                        }
                        break;
                    case 4:
                        questions[0] = "What did you give him?";
                        questions[1] = "Where was he located?";
                        if (!isLying)
                        {
                            answerID[0] = 16;
                            answerID[1] = 18;
                        }
                        else if (isLying)
                        {
                            answerID[0] = 17;
                            answerID[1] = 19;
                        }
                        break;
                }
                break;

            default:
                print("Invalid input");
                break;
        }
    }

    public void GetAnswers(int ID)
    {
        answerFile = new StreamReader(Application.dataPath + "/Dialog Resources/" + AnswerFile[charAlignment].name + ".txt");
        answerContents = answerFile.ReadToEnd();
        print("AnswersRead");
        answerFile.Close();

        answers = answerContents.Split("\n"[0]);
        answerTxt = answers[answerID[ID]]; 

    }
}