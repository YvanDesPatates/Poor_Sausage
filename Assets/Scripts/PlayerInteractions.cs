using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private GameControllerScript _gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deadly Obstacle"))
        {
            _gameController.GameOver();
        }
    }
}
