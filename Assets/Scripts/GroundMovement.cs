using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private float speed = 5f;
    private Vector2 direction;
    public Transform groundParent;
    private float newPositionX = -40f;
    private int childCount;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(-1, 0);
        childCount = groundParent.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks when it's off camera and moves it
        if(transform.position.x < -11f)
        {
            GetLastPosition();
            transform.position = new Vector2(newPositionX + 5.5f, transform.position.y);
        }

        // Movement
        transform.Translate(direction * (speed + GameBehaviour.realAcceleration) * Time.deltaTime);
    }

    void GetLastPosition()
    {
        // Get last ground position
        for (int i = 0; i < childCount; i++)
        {
            if (groundParent.GetChild(i).transform.position.x > newPositionX)
            {
                newPositionX = groundParent.GetChild(i).transform.position.x;
            }
        }
    }
}
