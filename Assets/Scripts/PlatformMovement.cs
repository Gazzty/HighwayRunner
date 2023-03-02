using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed, acceleration;
    public Vector2 direction = new Vector2(-1, 0);

    private void Start()
    {
        // We get the speed from the grandparent
        acceleration = GameBehaviour.realAcceleration;
    }
    void Update()
    {
        // Move platform
        transform.Translate(direction * (speed + acceleration) * Time.deltaTime);
        if(transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
} 