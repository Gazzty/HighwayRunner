using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject carPrefab, busPrefab, signPrefab;
    public Transform parent;

    private float choosePlatform = -1, count = 0;
    private GameObject newPlatform;
    //private Vector2 oldPlatformPosition;
    //private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        newPlatform = Instantiate(carPrefab);
        newPlatform.transform.position = new Vector2(8.5f, -4.75f);
        newPlatform.transform.SetParent(parent);
        // Call coroutine to spawn infinite platforms
        StartCoroutine(SpawnPlatform());
    }

    IEnumerator SpawnPlatform()
    {
        // Wait so we don't get so much platforms
        yield return new WaitForSeconds(1.5f);

        //Create the next platform
        // Chooses from 0-2 and depending the result it spawns a platform
        // No elige el sign si la anterior plataforma no fue un bus
        if(choosePlatform >= 1)
        {
            choosePlatform = Random.Range(0,3); // Se usa 0,3 ya que el rango es [0,3)
        }
        else
        {
            choosePlatform = Random.Range(0, 2);
        }
        switch (choosePlatform)
        {
            case 0:
                newPlatform = Instantiate(carPrefab);
                newPlatform.transform.position = new Vector2(8.5f, -4.8f);
                break;
            case 1:
                newPlatform = Instantiate(busPrefab);
                newPlatform.transform.position = new Vector2(9.6f, -4.7f);
                break;
            case 2:
                newPlatform = Instantiate(signPrefab);
                newPlatform.transform.position = new Vector2(8.5f, -2.2f);
                break;
            default:
                yield return null;
                break;
        }
        newPlatform.transform.SetParent(parent);

        // Spawns regular signs to make it look more random
        if(choosePlatform != 2 && count == 3)
        {
            newPlatform = Instantiate(signPrefab);
            newPlatform.transform.position = new Vector2(8.5f, -2.2f);
            newPlatform.transform.SetParent(parent);
            count = 0;
        }
        else
        {
            count++;
        }
        // Repeat coroutine infinitely
        StartCoroutine(SpawnPlatform());
    }
}
