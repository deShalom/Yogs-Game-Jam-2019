using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayCount : MonoBehaviour
{
    public Text dayTxt;
    public GameObject self;
    void Start()
    {
        dayTxt.text = DayCycles.statDays.ToString();

    }

    
}
