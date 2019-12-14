using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMananger_script : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GiftText;

    public void UpdateScore(float score)
    {
        ScoreText.text = "Score: " + score.ToString("F0");
    }

    public void UpdateGift(int gift)
    {
        GiftText.text = "Gifts Left: " + gift;
    }
}
