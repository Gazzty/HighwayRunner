using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());   
    }

    IEnumerator SpawnObstacle() {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.SetParent(parent);
        newObstacle.transform.position = new Vector2(6f, Random.Range(-1.5f,-4.5f));
        //newObstacle.transform.localScale = new Vector2(newObstacle.transform.localScale.x, Random.Range(.3f, 1f));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(SpawnObstacle());
    }
}
