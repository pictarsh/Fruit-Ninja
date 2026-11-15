
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitSpawnerScripts : MonoBehaviour
{

    public GameObject[] objectPrefab;
    public Transform[] spawnPoints;
    public float minDelay = 0.5f, maxDelay = 2f;
    public AudioSource explode;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int indexPosition = Random.Range(0, spawnPoints.Length);
            
            Instantiate(Random.Range(0,2) == 1 ? objectPrefab[Random.Range(0, 2)] : objectPrefab[0], spawnPoints[indexPosition].position, spawnPoints[indexPosition].rotation);
            
            // if (Random.Range(0, 2) == 1)
            // {
            //     Instantiate(objectPrefab[Random.Range(0, 2)], spawnPoints[indexPosition].position, spawnPoints[indexPosition].rotation);
            // }
            // else
            // {
            //     Instantiate(objectPrefab[0], spawnPoints[indexPosition].position, spawnPoints[indexPosition].rotation);
            // }
        }
    }

    public void StopSpawning()
    {
        explode.Play();
        StopAllCoroutines();
    }

    // public GameObject fruitPrefab;
    // public GameObject[] prefabsObjects;
    // public Transform[] fruitSpawnPoints;
    // public float minDelay = 0.5f, maxDelay = 2f;
    // public AudioSource explode;
    //
    // void Start()
    // {
    //     StartCoroutine(SpawnFruit());
    // }
    // IEnumerator SpawnFruit()
    // {
    //     while (true)
    //     {
    //         float delay = Random.Range(minDelay, maxDelay);
    //         yield return new WaitForSeconds(delay);
    //
    //         int indexPosition = Random.Range(0, fruitSpawnPoints.Length);
    //         if (Random.Range(0, 2) > 0)
    //         {
    //             Instantiate(fruitPrefab, fruitSpawnPoints[indexPosition].position, fruitSpawnPoints[indexPosition].rotation);
    //         }
    //         else
    //         {
    //             Instantiate(prefabsObjects[Random.Range(0, 2)], fruitSpawnPoints[indexPosition].position,
    //                 fruitSpawnPoints[indexPosition].rotation);
    //         }
    //
    //     }
    // }
    //
    // public void StopSpawning()
    // {
    //     explode.Play();
    //     StopAllCoroutines();
    // }
}
