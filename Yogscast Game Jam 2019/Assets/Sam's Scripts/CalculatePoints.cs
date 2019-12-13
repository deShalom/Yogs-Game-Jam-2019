using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CalculatePoints : MonoBehaviour
{
    int NumberOfBadKidsKicked = 2;
    int NumberOfGoodKidsGifted = 3;
    int NumberOfBadKidsGifted = 1;
    int NumberOfGoodKidsKicked = 1;
    int TotalPoints;
    public Text points;
    public Text speedText;
    public Button speedButton;
    
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
        speedText.text = "Sold Out!";
        speedButton.interactable = false;
        TotalPoints -= 30;
        UpdatePoints();
    }
}
