using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMananger_script : MonoBehaviour
{
    public float MainScore;
    public Transform PlayerTransform;
    private UIMananger_script _uiMananger;

    void Start()
    {
        _uiMananger = GetComponent<UIMananger_script>();
        _uiMananger.UpdateScore(MainScore);
    }

    public void AddScore(float score)
    {
        Debug.Log("Add Score Start");
        if (score < 0) //taking damage
        {
            MainScore += score;
            _uiMananger.UpdateScore(MainScore);
            return;
        }
        float temp;
        temp = score * PlayerTransform.transform.position.y;
        if (temp < 0)
        {
            temp = (score * 10) / 100;
        }
        MainScore += temp;
        Debug.Log("Add Score - " +temp);
        _uiMananger.UpdateScore(MainScore);
        //score sound, effects
    }
}
