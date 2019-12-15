using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CalculatePoints : MonoBehaviour
{
    static int TotalPoints;
    public GameObject Dialog;
    public GameObject Days;
    public int charalign;

    public Text points;
    public Text speedText;
    public Button speedButton;
    public Text kickText;
    public Button kickButton;
    public Text extraDText;
    public Button extraDButton;

    public static bool speedBuy;
    public static bool kickBuy;
    public static bool dayBuy;
    public static bool speedUsed = false;
    public static bool dayUsed = false;

    void Start()
    {
        AnyBought();
        UpdatePoints();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "UpgradesScene")
        {
            charalign = Dialog.GetComponent<DialogueManager>().charAlignment;
        }
    }

    public void UpdatePoints() //updates point value
    {
        points.text = TotalPoints.ToString();
    }

    public void SpeedPurchase()
    {
        if (TotalPoints >= 30)
        {
            speedText.text = "Sold Out!";
            speedButton.interactable = false;
            TotalPoints = TotalPoints - 30;
            speedBuy = true;
            UpdatePoints();
        }
    }

    public void BootPurchase()
    {
        if (TotalPoints >= 60)
        {
            kickText.text = "Sold Out!";
            kickButton.interactable = false;
            TotalPoints = TotalPoints - 60;
            kickBuy = true;
            UpdatePoints();
        }
    }

    public void ExtraDay()
    {
        if (TotalPoints >= 120)
        {
            extraDText.text = "Sold Out!";
            extraDButton.interactable = false;
            TotalPoints = TotalPoints - 120;
            dayBuy = true;
            UpdatePoints();
        }
    }

    void AnyBought() //checks to see what power-ups have already been purchased
    {
        if(SceneManager.GetActiveScene().name == "UpgradesScene") { 
            if (speedBuy)
            {
                speedText.text = "Sold Out!";
                speedButton.interactable = false;
            }
            if (kickBuy)
            {
                kickText.text = "Sold Out!";
                kickButton.interactable = false;
            }
            if (dayBuy)
            {
                extraDText.text = "Sold Out!";
                extraDButton.interactable = false;
            }
        }
        else
        {
            if (speedBuy && !speedUsed)
            {
                DayCycles.nOfViewers++;
                speedUsed = true;
            }
            if (dayBuy && dayUsed)
            {
                DayCycles.Days++;
                dayUsed = true;
            }
        }
    }

    public void Gifted()
    {
        if (charalign == 2)
        {
            TotalPoints = TotalPoints + 10;
            UpdatePoints();
        }

        if (charalign == 1)
        {
            TotalPoints = TotalPoints + 5;
            UpdatePoints();
        }

        else
        {
            TotalPoints = TotalPoints - 5;
            UpdatePoints();
        }
    }

    public void Kicked()
    {
        if (charalign == 2)
        {
            TotalPoints = TotalPoints - 5;
            UpdatePoints();
        }

        if (charalign == 1)
        {
            TotalPoints = TotalPoints + 0;
            UpdatePoints();
        }

        else
        {
            TotalPoints = TotalPoints + 10;
            UpdatePoints();
        }
    }
}
