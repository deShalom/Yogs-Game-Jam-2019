using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public int charAlignment;
    public string reason;
    public TextAsset[] dialogFile;

    // Start is called before the first frame update
    void Start()
    {
        charAlignment = Random.Range(0,3);
        
        GetReason();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetReason()
    {
        string[] lines = dialogFile[charAlignment].text.Split('\n');
        string[][] linePairs = new string[lines.Length][];
        int num = 0;
        foreach (string line in lines)
        {
            linePairs[num++] = line.Split('.');
            print(line);
        }
        
    }
}