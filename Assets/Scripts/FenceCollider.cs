using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCollider : MonoBehaviour
{
    private SpriteRenderer sprite;
    private BoxCollider2D col;

    public float speed;
    private Vector2 direction;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = gameObject.AddComponent<BoxCollider2D>();
        col.size = new Vector2(sprite.size.x, 0.45f);
        
    }

    private void Update()
    {
        direction = new Vector2(-speed * Time.deltaTime, 0);
        transform.Translate(direction);

        if(gameObject.transform.position.x < -40f)
        {
            Destroy(gameObject);
        }
    }
}
