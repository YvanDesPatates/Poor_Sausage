using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectibleManagerScript : MonoBehaviour
{
    public List<Transform> collectibleSpawns;
    public GameObject classicCollectiblePrefab;
    public GameObject superCollectiblePrefab;
    public float superCollectibleSecondsBeforeNextSpawn = 8;
    public float superCollectibleSecondsBeforeDisappear = 5;
    
    private GameControllerScript _gameController;
    private GameObject _currentSuperCollectible;
    // Start is called before the first frame update
    void Start()
    {
        if (collectibleSpawns.Count == 0)
        {
            throw new MissingFieldException("collectibleSpawns cannot be empty.");
        }
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
        SpawnCollectible(classicCollectiblePrefab);
        StartCoroutine(SpawnSuperCollectible());
    }

    public void CollectibleWasPickedUp(GameObject collectible)
    {
        _gameController.PlayerPickedUpCollectibe();
        Destroy(collectible);
        SpawnCollectible(classicCollectiblePrefab);
    }
    
    public void SuperCollectibleWasPickedUp(GameObject collectible)
    {
        _gameController.PlayerPickedUpCollectibe();
        Destroy(collectible);
    }
    
    private GameObject SpawnCollectible(GameObject prefabToSpawn)
    {
        int spawnIndex = Random.Range(0, collectibleSpawns.Count);
        GameObject collectible = Instantiate(prefabToSpawn, collectibleSpawns[spawnIndex].position, Quaternion.identity);
        collectible.GetComponent<CollectibleSrcipt>().SetCollectibleManager(this);
        return collectible;
    }
    
    //coroutine to spawn super collectible every 10 seconds
    private IEnumerator SpawnSuperCollectible()
    {
        while (true)
        {
            Destroy(_currentSuperCollectible);
            yield return new WaitForSeconds(superCollectibleSecondsBeforeNextSpawn);
            _currentSuperCollectible = SpawnCollectible(superCollectiblePrefab);
            yield return new WaitForSeconds(superCollectibleSecondsBeforeDisappear);
        }
    }
    
    
}
