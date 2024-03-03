using UnityEngine;

public class CollectibleSrcipt : MonoBehaviour
{
    public float rotationSpeed = 10;
    
    private GameControllerScript _gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up,  rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameController.IncrementScore();
            Destroy(gameObject);
        }
    }
}
