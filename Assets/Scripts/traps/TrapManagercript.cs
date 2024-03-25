using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManagercript : MonoBehaviour, IGameOverObserver
{
    public List<GameObject> trapPrefabs;
    public float spawnRateInS = 5f;
    
    private GameControllerScript _gameController;
    private bool _doSpawnTraps = true;
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
        _gameController.SubscribeToGameOverNotification(this);
        SpawnTrap(trapPrefabs[0]);
        StartCoroutine(SpawnTraps());
    }
    
    private IEnumerator SpawnTraps()
    {
        while (_doSpawnTraps)
        {
            yield return new WaitForSeconds(spawnRateInS);
            int index = Random.Range(0, trapPrefabs.Count);
            if (_doSpawnTraps)
            {
                SpawnTrap(trapPrefabs[index]);
            }
        }
    }
    
    private void SpawnTrap(GameObject trapPrefab)
    {
        var trap = Instantiate(trapPrefab);
        var observer = trap.GetComponent<IGameOverObserver>();
        if (observer != null)
        {
            _gameController.SubscribeToGameOverNotification(observer);
        }
    }

    public void GameOverNotification()
    {
        _doSpawnTraps = false;
    }
}
