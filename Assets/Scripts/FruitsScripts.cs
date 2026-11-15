
using UnityEngine;

public class FruitsScripts : MonoBehaviour
{
    public GameObject melonSlicedPrefab;
    public float speedLaunched = 1f;
    public Vector3 offset;
    
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.up * speedLaunched,  ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            
            Vector3 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Destroy(gameObject);
            Instantiate(melonSlicedPrefab, transform.position + offset, rotation);
            other.gameObject.GetComponent<BladeScripts>().AddScore();
            // x=
        }
    }
}
