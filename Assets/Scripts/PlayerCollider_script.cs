using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider_script : MonoBehaviour
{
    private Dropper_script _dropper;
    private ScoreMananger_script _scoreMananger;
    private BoxCollider2D _col;
    private SpriteRenderer[] _spriteRenderers;
    public int HitPenelaty;

    void Start()
    {
        _dropper = GetComponent<Dropper_script>();
        _scoreMananger = _dropper.GameManger.GetComponent<ScoreMananger_script>();
        _col = GetComponent<BoxCollider2D>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Obstacle")
        {
            _dropper.DmgDrop();
            //sound effect etc
            _scoreMananger.AddScore(HitPenelaty);
            StartCoroutine("InvisiFrames");
        }
    }

    IEnumerator InvisiFrames()
    {
        _col.enabled = false;
        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = false;
        }
        yield return new WaitForSeconds(0.15f);

        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = true;
        }
        yield return new WaitForSeconds(0.15f);

        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = false;
        }
        yield return new WaitForSeconds(0.15f);

        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = true;
        }
        yield return new WaitForSeconds(0.15f);

        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = false;
        }
        yield return new WaitForSeconds(0.15f);

        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = true;
        }
        yield return new WaitForSeconds(0.15f);

        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = false;
        }
        yield return new WaitForSeconds(0.15f);

        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = true;
        }

        _col.enabled = true;
    }
}
