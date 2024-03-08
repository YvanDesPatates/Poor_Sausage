using UnityEngine;

public abstract class CollectibleSrcipt : MonoBehaviour
{
    public float rotationSpeed = 10;

    private CollectibleManagerScript _collectibleManager; 
    
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up,  rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AlertManagerCollectibleWasPickedUp();
        }
    }
    
    public void SetCollectibleManager(CollectibleManagerScript collectibleManager)
    {
        _collectibleManager = collectibleManager;
    }

    protected abstract void AlertManagerCollectibleWasPickedUp();
    
    protected CollectibleManagerScript GetCollectibleManager()
    {
        return _collectibleManager;
    }
}
