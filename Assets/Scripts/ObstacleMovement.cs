using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Collision2D collisison;
    public float speed;

    private void Start()
    {
        speed = Random.Range(1f, 3f);
        // Add acceleration from grandparent
        speed += GameBehaviour.realAcceleration;
    }

    public void Update()
    {
        // Move obstacle
        Vector2 direction = new Vector2(-1, 0);
        transform.Translate(direction * (speed + GameBehaviour.realAcceleration) * Time.deltaTime);
        if(transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying= false;
#else
            Application.Quit();
#endif
        }
    }
}
