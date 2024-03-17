using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private GameControllerScript _gameController;
    
    // Start is called before the first frame update
    private void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        GameOverOnCollision(other.gameObject);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        GameOverOnCollision(other.gameObject);
    }
    
    private void GameOverOnCollision(GameObject other)
    {
        if (other.CompareTag("Deadly Obstacle"))
        {
            _gameController.GameOver();
        }
    }
}
