using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DaysCount : MonoBehaviour
{
    public Text dayTxt;
    void Start()
    {
        dayTxt.text = DayCycles.Days.ToString();
    }

}
