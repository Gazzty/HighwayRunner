using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawn : MonoBehaviour
{
    public GameObject fencePrefab;
    private GameObject oldFence;
    private float positionY = -5.55f;
    public Transform parent;
    private SpriteRenderer sprite;
    private void Start()
    {
        // Spawn first fence
        GameObject newFence = Instantiate(fencePrefab);
        oldFence = transform.GetChild(0).gameObject;

        // Fence position
        sprite = newFence.GetComponent<SpriteRenderer>();
        newFence.transform.position = new Vector2(10f, positionY);
        newFence.transform.SetParent(parent);   // Set parent

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        // If there are too many platforms it waits
        while(oldFence.transform.position.x < 30f)
        {
            // Spawn newFence and save it in the oldFence
            GameObject newFence = Instantiate(fencePrefab);
            sprite = newFence.GetComponent<SpriteRenderer>(); // Update sprite

            //Set position
            // With the calculations here I check the position of the old fence and the distance to the end so I can spawn at the end of it
            newFence.transform.position = new Vector2(oldFence.transform.position.x + sprite.size.x + Random.Range(.5f, 5), positionY);
            newFence.transform.SetParent(parent);   // Set parent
            oldFence = newFence;
        }
        yield return null;

        StartCoroutine(Spawn());
    }
}
