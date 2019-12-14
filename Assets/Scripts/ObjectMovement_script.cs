using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement_script : MonoBehaviour
{
    public float[] MoveSpeed;
    private float _activeSpeed;
    public bool RandomSpeed;

    void Start()
    {
        _activeSpeed = MoveSpeed[0];
        if (RandomSpeed)
        {
            int r = Random.Range(0, MoveSpeed.Length);
            _activeSpeed = MoveSpeed[r];
        }
    }

    void FixedUpdate()
    {
        DoMove();

    }

    void Update()
    {
        CheckPos();
    }

    private void DoMove()
    {
        float step = _activeSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * step);
    }

    private void CheckPos()
    {
        if (this.transform.position.x < -25f)
        {
            Destroy(this.gameObject);
        }
    }
}
