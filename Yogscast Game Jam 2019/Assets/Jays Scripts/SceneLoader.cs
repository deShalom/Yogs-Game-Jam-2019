using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Variables
    public string scnName;

    private void Start()
    {

    }

    //Methods
    void loadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

}
//All code written by Jay Underwood (deShalom).