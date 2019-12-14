using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject_script : MonoBehaviour
{
    public int BaseScore;
    private ScoreMananger_script _scoreMananger;
    private bool _obstacleHit;
    public float LifeTime;
    public float FadeTime;

    public void Config(GameObject gm)
    {
        _scoreMananger = gm.GetComponent<ScoreMananger_script>();
        StartCoroutine("RemoveObject");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Obstacle")
        {
            BaseScore /= 4;
            _obstacleHit = true;
            Debug.Log("House hit new base score - " +BaseScore );
        }
        if (col.transform.tag == "Finish")
        {
            Debug.Log("Drop Object Hit");
            if (col.transform.position.x > this.transform.position.x - 0.15f 
                && col.transform.position.x < this.transform.position.x + 0.15f 
                  && !_obstacleHit)
            {
                BaseScore *= 2;
                Debug.Log("Bullz eye");
            }
            _scoreMananger.AddScore(BaseScore);
            Destroy(this.gameObject);
        }
        
    }

    IEnumerator RemoveObject()
    {
        yield return new WaitForSeconds(LifeTime);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / FadeTime)
        {
            float x = Mathf.Lerp(this.transform.localScale.x, 0, t);
            float y = Mathf.Lerp(this.transform.localScale.y, 0, t);
            this.transform.localScale =  new Vector3(x,y,1);
            yield return null;
        }
    }
}
