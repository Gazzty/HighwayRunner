using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public float acceleration;
    public static float realAcceleration;
    public float increment = .3f;
    private void Start()
    {
        InvokeRepeating("GameSpeed", 10f, 10f);
    }

    private void GameSpeed()
    {
        acceleration += increment;
        realAcceleration = acceleration;    
    }
}