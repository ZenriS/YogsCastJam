using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreText_script : MonoBehaviour
{
    public float LifeTime;
    private TextMeshPro _scoreText;
    private bool _bullz;

    public void Config(bool bullz, float score)
    {
        _scoreText = GetComponent<TextMeshPro>();
        _scoreText.text = "";
        _bullz = bullz;
        if (score < 0)
        {
            _scoreText.color = Color.red;
        }
        if (_bullz)
        {
            _scoreText.text = "Perfect!\n";
            _scoreText.color = Color.green;
        }
        _scoreText.text += score.ToString("F0");
        

        StartCoroutine("Effects");
    }

    IEnumerator Effects()
    {
        Vector3 size = new Vector3(1,1,1);
        if (_bullz)
        {
            size = new Vector3(2, 2, 1);
        }
        this.transform.DOScale(size, LifeTime / 2);
        this.transform.DOMoveY(2, LifeTime);
        yield return new WaitForSeconds(LifeTime / 4);
        float t = (LifeTime * 1.4f) - LifeTime;
        this.transform.DOScale(new Vector3(0, 0, 1), t);
        yield return new WaitForSeconds(t +5f);
        Destroy(this.gameObject);
    }
}
