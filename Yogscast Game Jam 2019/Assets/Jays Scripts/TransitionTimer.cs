using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTimer : MonoBehaviour
{
    public float timer;

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer != 0)
        {
            timer = 0;
            SceneManager.LoadScene("UpgradesScene");
        }
    }
}
