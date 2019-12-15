using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CalculatePoints : MonoBehaviour
{
    static int TotalPoints;
    public GameObject Dialog;
    public int charalign;

    public Text points;
    public Text speedText;
    public Button speedButton;
    public Text kickText;
    public Button kickButton;
    public Text extraDText;
    public Button extraDButton;

    static bool speedBuy = false;
    static bool kickBuy = false;
    static bool dayBuy = false;

    void Start()
    {
        AnyBought();
        UpdatePoints();
    }

    private void Update()
    {
        charalign = Dialog.GetComponent<DialogueManager>().charAlignment;
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
            TotalPoints -= 30;
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
            TotalPoints -= 60;
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
            TotalPoints -= 120;
            dayBuy = true;
            UpdatePoints();
        }
    }

    void AnyBought() //checks to see what power-ups have already been purchased
    {
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

    public void Gifted()
    {
        if (charalign == 2)
        {
            TotalPoints = TotalPoints + 10;
        }

        if (charalign == 1)
        {
            TotalPoints = TotalPoints + 5;
        }

        else
        {
            TotalPoints = TotalPoints - 5;
        }
    }

    public void Kicked()
    {
        if (charalign == 2)
        {
            TotalPoints = TotalPoints - 5;
        }

        if (charalign == 1)
        {
            TotalPoints = TotalPoints + 0;
        }

        else
        {
            TotalPoints = TotalPoints + 10;
        }
    }
}
