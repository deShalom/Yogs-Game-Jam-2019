using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public int charAlignment;
    public string contents, reasonTxt;
    public string[] reason;
    public TextAsset[] dialogueFile;
    public bool isLying;

    public StreamReader txtFile;
    
    // Start is called before the first frame update
    void Start()
    {           
        //Testing on Start
        GetReason();
    }

   

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
    }
    public void GetReason()
    {
        //Setup of alignment and generation of Reason
        charAlignment = Random.Range(0, 3);
        txtFile = new StreamReader(Application.dataPath + "/Dialog Resources/" + dialogueFile[charAlignment].name + ".txt");
        contents = txtFile.ReadToEnd();
        txtFile.Close();
        
        reason = contents.Split("\n"[0]);
        reasonTxt = reason[Random.Range(0, 5)];
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
}