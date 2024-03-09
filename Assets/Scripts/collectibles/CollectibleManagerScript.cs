using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CollectibleManagerScript : MonoBehaviour
{
    public List<Transform> collectibleSpawns;
    public GameObject classicCollectiblePrefab;
    public GameObject superCollectiblePrefab;
    //time between two super collectible spawn
    public float secondsBetweenTwoScSpawn = 8;
    //time before super collectible disappear after spawn
    public float secondsScStayOnTheMap = 5;
    
    private GameControllerScript _gameController;
    // Start is called before the first frame update
    void Start()
    {
        if (collectibleSpawns.Count == 0)
        {
            throw new MissingFieldException("collectibleSpawns cannot be empty.");
        }
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
        SpawnCollectible(classicCollectiblePrefab);
        StartCoroutine(SpawnSuperCollectibles());
    }

    public void CollectibleWasPickedUp(GameObject collectible)
    {
        _gameController.PlayerPickedUpCollectible();
        Destroy(collectible);
        SpawnCollectible(classicCollectiblePrefab);
    }
    
    public void SuperCollectibleWasPickedUp(GameObject collectible)
    {
        _gameController.PlayerPickedUpSuperCollectible();
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
    private IEnumerator SpawnSuperCollectibles()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenTwoScSpawn);
            GameObject superCollectible = SpawnCollectible(superCollectiblePrefab);
            StartCoroutine(DestroySuperCollectibleAfterTime(superCollectible));
        }
    }
    
    private IEnumerator DestroySuperCollectibleAfterTime(GameObject superCollectible)
    {
        yield return new WaitForSeconds(secondsScStayOnTheMap);
        Destroy(superCollectible);
    }
}
