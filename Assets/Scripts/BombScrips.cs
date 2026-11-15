using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScrips : MonoBehaviour
{
    public float speedLaunched = 1f;
    public GameObject explosion;
    public FruitSpawnerScripts fruitSpawnerScripts;

    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.up * speedLaunched,  ForceMode.Impulse);
        fruitSpawnerScripts = FindFirstObjectByType<FruitSpawnerScripts>();
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Blade"))
    //     {
    //         print("Game Over!");
    //         // Instantiate(explosion, transform.position, Quaternion.identity);
    //         // fruitSpawnerScripts.StopSpawning();
    //         other.gameObject.GetComponent<BladeScripts>().ActivateGameOverFrame();
    //         Destroy(gameObject);
    //     }
    // }
}
