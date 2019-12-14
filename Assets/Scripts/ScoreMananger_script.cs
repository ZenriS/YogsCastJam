using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMananger_script : MonoBehaviour
{
    public float MainScore;
    private UIMananger_script _uiMananger;
    public int GiftDelivered;
    public EffectManager_script EffectManager;
    public AudioClip AudioClip;

    void Start()
    {
        _uiMananger = GetComponent<UIMananger_script>();
        _uiMananger.UpdateScore(MainScore);
    }

    public void AddScore(float score)
    {
        //Debug.Log("Add Score Start");
        if (score < 0) //taking damage
        {
            MainScore += score;
            _uiMananger.UpdateScore(MainScore);
            return;
        }
        if (score < 0)
        {
            score = (score * 10) / 100;
        }
        MainScore += score;
        EffectManager.PlaySFX(AudioClip);
        if (MainScore < 0)
        {
            MainScore = 0;
        }
        //Debug.Log("Add Score - " +temp);
        GiftDelivered++;
        _uiMananger.UpdateScore(MainScore);
        //score sound, effects
    }

    public void RestartValues()
    {
        GiftDelivered = 0;
        MainScore = 0;
        _uiMananger.UpdateScore(MainScore);
    }
}
