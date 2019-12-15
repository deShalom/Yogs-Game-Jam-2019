using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject audiomanager;

    public void openCloseOptions()
    {
        if (audiomanager.activeSelf)
            audiomanager.SetActive(false);
        else
            audiomanager.SetActive(true);
    }
}
