using UnityEngine;

public class CollectibleSrcipt : MonoBehaviour
{
    public float rotationSpeed = 10;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up,  rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
