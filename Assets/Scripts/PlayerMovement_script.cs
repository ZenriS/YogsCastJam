using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_script : MonoBehaviour
{

    public float MoveSpeed;
    
    void Update()
    {
        DoMove();
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
