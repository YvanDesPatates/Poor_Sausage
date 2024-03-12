using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManagercript : MonoBehaviour
{
    public List<GameObject> trapPrefabs;
    public float spawnRateInS = 5f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTrap(trapPrefabs[0]);
        StartCoroutine(SpawnTraps());
    }
    
    private IEnumerator SpawnTraps()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRateInS);
            int index = Random.Range(0, trapPrefabs.Count);
            SpawnTrap(trapPrefabs[index]);
        }
    }
    
    private void SpawnTrap(GameObject trapPrefab)
    {
        Instantiate(trapPrefab);
    }
}
