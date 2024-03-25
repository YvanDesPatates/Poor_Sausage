using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverCanvas;
    public int superCollectibleValue = 3;

    private int _score = 0;
    private readonly List<IGameOverObserver> _gameOverObservers = new();
    
    public void PlayerPickedUpCollectible()
    {
        _score++;
        scoreText.text = _score.ToString();
    }
    public void PlayerPickedUpSuperCollectible()
    {
        _score += superCollectibleValue;
        scoreText.text = _score.ToString();
    }
    
    public void GameOver()
    {
        NotifyGameOverObservers();
        gameOverCanvas.SetActive(true);
    }
    
    public void SubscribeToGameOverNotification(IGameOverObserver observer)
    {
        _gameOverObservers.Add(observer);
    }
    
    private void NotifyGameOverObservers()
    {
        _gameOverObservers.ForEach(observer => observer.GameOverNotification());
    }
    
}
