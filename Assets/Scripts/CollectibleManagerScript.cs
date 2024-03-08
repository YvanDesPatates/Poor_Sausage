using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectibleManagerScript : MonoBehaviour
{
    public List<Transform> collectibleSpawns;
    public GameObject collectiblePrefab;
    
    private GameControllerScript _gameController;
    // Start is called before the first frame update
    void Start()
    {
        if (collectibleSpawns.Count == 0)
        {
            throw new MissingFieldException("collectibleSpawns cannot be empty.");
        }
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
        SpawnCollectible();
    }

    public void CollectibleWasPickedUp(GameObject collectible)
    {
        _gameController.IncrementScore();
        Destroy(collectible);
        SpawnCollectible();
    }
    
    private void SpawnCollectible()
    {
        int spawnIndex = Random.Range(0, collectibleSpawns.Count);
        GameObject collectible = Instantiate(collectiblePrefab, collectibleSpawns[spawnIndex].position, Quaternion.identity);
        collectible.GetComponent<CollectibleSrcipt>().SetCollectibleManager(this);
    }
    
    
}
