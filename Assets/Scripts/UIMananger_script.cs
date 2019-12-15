using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMananger_script : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GiftText;
    public GameObject GameOverUI;
    private TextMeshProUGUI[] _gameOverTexts;
    public GameObject StartScreen;
    public GameObject TopUI;

    void Start()
    {
        _gameOverTexts = GameOverUI.GetComponentsInChildren<TextMeshProUGUI>();
        StartScreen.SetActive(true);
        GameOverUI.SetActive(false);
    }


    public void UpdateScore(float score)
    {
        ScoreText.text = "Score: " + score.ToString("F0");
    }

    public void UpdateGift(int gift)
    {
        GiftText.text = "Gifts Left: " + gift;
    }

    public void ToggleGameOverUI(bool b, float score, int gifts)
    {
        GameOverUI.SetActive(b);
        TopUI.SetActive(!b);
        _gameOverTexts[2].text = gifts.ToString("F0");
        _gameOverTexts[4].text = score.ToString("F0");
        
    }
}
