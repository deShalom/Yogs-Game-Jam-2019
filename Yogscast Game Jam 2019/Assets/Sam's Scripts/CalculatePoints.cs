using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CalculatePoints : MonoBehaviour
{
    int NumberOfBadKidsKicked = 6;
    int NumberOfGoodKidsGifted = 3;
    int NumberOfBadKidsGifted = 0;
    int NumberOfGoodKidsKicked = 1;
    int TotalPoints;
    public Text points;
    public Text speedText;
    public Button speedButton;
    public Text kickText;
    public Button kickButton;
    public Text extraDText;
    public Button extraDButton;

    void Start()
    {
        CalcPoints();
    }

    void CalcPoints()
    {
        TotalPoints = TotalPoints + (NumberOfBadKidsKicked * 10);
        TotalPoints = TotalPoints + (NumberOfGoodKidsGifted * 10);
        TotalPoints = TotalPoints - (NumberOfGoodKidsKicked * 10);
        TotalPoints = TotalPoints - (NumberOfBadKidsGifted * 10);

        UpdatePoints();
    }

    void UpdatePoints()
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
            UpdatePoints();
        }
    }
}
