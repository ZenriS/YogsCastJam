using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DropObject_script : MonoBehaviour
{
    public int BaseScore;
    private ScoreMananger_script _scoreMananger;
    private bool _obstacleHit;
    public float LifeTime;
    public float FadeTime;
    private Rigidbody2D _rigidbody;
    private float _dropHeigh;
    public ScoreText_script ScoreTextPrefab;
    private EffectManager_script _effectManager;
    public AudioClip AudioClip;


    public void Config(GameObject gm, float y)
    {
        _scoreMananger = gm.GetComponent<ScoreMananger_script>();
        _effectManager = _scoreMananger.EffectManager;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _dropHeigh = y;
        StartCoroutine("RemoveObject");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        bool bullz = false;
        if (col.transform.tag == "Obstacle")
        {
            BaseScore /= 4;
            _obstacleHit = true;
            _effectManager.PlaySFX(AudioClip);
            //Debug.Log("House hit new base score - " +BaseScore );
        }
        if (col.transform.tag == "Finish")
        {
            //Debug.Log("Drop Object Hit");
            if (col.transform.position.x > this.transform.position.x - 0.15f 
                && col.transform.position.x < this.transform.position.x + 0.15f 
                  && !_obstacleHit)
            {
                BaseScore *= 2;
                bullz = true;
                //Debug.Log("Bullz eye");
            }

            float score = BaseScore * _dropHeigh;
            //Debug.Log("Score calc " + BaseScore + " * " + _dropHeigh + " = " + score);
            ScoreText_script sc = Instantiate(ScoreTextPrefab, this.transform.position, Quaternion.identity,
                this.transform.parent);
            sc.Config(bullz, score);
            _scoreMananger.AddScore(score);
            Destroy(this.gameObject);
        }
        
    }

    IEnumerator RemoveObject()
    {
        yield return new WaitForSeconds(LifeTime);
        this.transform.DOScale(new Vector3(0, 0, 1), FadeTime);
    }
}
