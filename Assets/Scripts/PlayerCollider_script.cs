using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider_script : MonoBehaviour
{
    private Dropper_script _dropper;
    private ScoreMananger_script _scoreMananger;
    private BoxCollider2D _col;
    private SpriteRenderer[] _spriteRenderers;
    public float HitPenelaty;
    private GameController_script _gameController;
    public ScoreText_script ScoreTextPrefab;
    public EffectManager_script EffectManager;
    public AudioClip AudioClip;
    private bool _noColide;


    void Start()
    {
        _dropper = GetComponent<Dropper_script>();
        _scoreMananger = _dropper.GameManger.GetComponent<ScoreMananger_script>();
        _col = GetComponent<BoxCollider2D>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _gameController = _scoreMananger.GetComponent<GameController_script>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Obstacle" && !_gameController.IsGameOver && !_noColide)
        {
            _dropper.DmgDrop();
            EffectManager.PlaySFX(AudioClip);
            ScoreText_script st = Instantiate(ScoreTextPrefab, this.transform.position, Quaternion.identity,
                _dropper.DroppObjectHolder);
            st.Config(false, HitPenelaty);
            Physics2D.IgnoreLayerCollision(9,10,true);
            //sound effect etc
            _scoreMananger.AddScore(HitPenelaty);
            StartCoroutine("InvisiFrames");
        }
    }

    IEnumerator InvisiFrames()
    {
        //_col.enabled = false;
        _noColide = true;
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

        _noColide = false;
        Physics2D.IgnoreLayerCollision(9, 10, false);
        //_col.enabled = true;
    }

    public void ResetValue()
    {
        StopAllCoroutines();

        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.enabled = true;
            _noColide = true;
            Physics2D.IgnoreLayerCollision(9, 10, false);

            //_col.enabled = true;
        }
    }
}
