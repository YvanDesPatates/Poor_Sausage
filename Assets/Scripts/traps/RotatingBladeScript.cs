using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBladeScript : MonoBehaviour, IGameOverObserver
{
    public float rotationSpeed = 25;

    private static List<Transform> _spawnPoints;
    private bool _gameIsRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        if (_spawnPoints == null)
        {
            _spawnPoints = new List<Transform>();
            foreach (var spawnObject in GameObject.FindGameObjectsWithTag("Rotating Blade Spawns"))
            {
                _spawnPoints.Add(spawnObject.transform);
            }

            if (_spawnPoints.Count == 0)
            {
                throw new UnityException("laser trap need at least one spawn point! (with tag Laser Spawns)");
            }
        }

        Transform randomSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        float zRotation = Random.Range(0, 360);
        float yRotation = randomSpawn.rotation.eulerAngles.y;
        transform.SetPositionAndRotation(randomSpawn.position, Quaternion.Euler(0, yRotation, zRotation));
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameIsRunning)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
    
    public void GameOverNotification()
    {
        _gameIsRunning = false;
    }
}