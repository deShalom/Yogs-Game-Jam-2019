using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public ConvoScript convoScript;

    private void Awake()
    {
        convoScript = FindObjectOfType<ConvoScript>();
    }
    public void DiceFinishedRolling()
    {
        convoScript.diceHasRolled = true;
    }
    public void FinishedKicking()
    {
        Debug.Log("Finished kicking");
        convoScript.KickingFinished();
    }
}
