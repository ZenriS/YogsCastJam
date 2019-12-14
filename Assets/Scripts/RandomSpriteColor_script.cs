using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteColor_script : MonoBehaviour
{
    public Color[] Colors;
    

    void Start()
    {
        int r = Random.Range(0, Colors.Length);
        GetComponentInChildren<SpriteRenderer>().color = Colors[r];
    }

}
