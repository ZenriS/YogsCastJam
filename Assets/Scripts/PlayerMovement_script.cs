using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_script : MonoBehaviour
{

    public float MoveSpeed;
    private GameController_script _gameController;
    private Dropper_script _dropper;

    void Start()
    {
        _dropper = GetComponent<Dropper_script>();
        _gameController = _dropper.GameManger.GetComponent<GameController_script>();
    }
    
    void Update()
    {
        if (!_gameController.IsGameOver)
        {
            DoMove();
        }
    }

    void DoMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        hor *= MoveSpeed * Time.deltaTime;
        ver *= MoveSpeed * Time.deltaTime;
        transform.Translate((Vector3.right * hor + Vector3.up * ver));
    }
}
