using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement_script : MonoBehaviour
{
    public float[] MoveSpeedModifiers;
    private float _activeSpeed;
    public bool RandomSpeed;
    public bool StopMovement;
    public ObjectSpawner_script _objectSpawner;

    void Start()
    {
        if (_objectSpawner != null)
        {
            Config(_objectSpawner);
        }
    }

    public void Config(ObjectSpawner_script os)
    {
        _objectSpawner = os;
        _activeSpeed = MoveSpeedModifiers[0];
        if (RandomSpeed)
        {
            int r = Random.Range(0, MoveSpeedModifiers.Length);
            _activeSpeed = MoveSpeedModifiers[r];
        }
    }

    void FixedUpdate()
    {
        if (!StopMovement)
        {
            DoMove();
        }
    }

    void Update()
    {
        CheckPos();
    }

    private void DoMove()
    {
        float step = _activeSpeed * _objectSpawner.BaseMoveSpeed;
        step = step * Time.deltaTime;
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
