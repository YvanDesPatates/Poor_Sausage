using System;
using UnityEngine;

public class OnRestartClick : MonoBehaviour
{
    private GameControllerScript _gameController;
    public void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    public void OnMouseDown()
    {
        _gameController.RestartGame();
    }
}
