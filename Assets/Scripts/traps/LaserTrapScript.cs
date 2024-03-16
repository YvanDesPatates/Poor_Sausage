using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LaserTrapScript : MonoBehaviour
{
    private static List<Vector3> _initialPlacements;
    // Start is called before the first frame update
    void Start()
    {
        if (_initialPlacements == null)
        {
            _initialPlacements = new List<Vector3>();
            foreach (var spawnObject in GameObject.FindGameObjectsWithTag("Laser Spawns"))
            {
                _initialPlacements.Add(spawnObject.transform.position);
            }

            if (_initialPlacements.Count == 0)
            {
                throw new  UnityException("laser trap need at least one spawn point! (with tag Laser Spawns)");
            }
        }

        InitialRandomPlacement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitialRandomPlacement()
    {
        int index = Random.Range(0, _initialPlacements.Count);
        transform.SetPositionAndRotation(_initialPlacements[index], transform.rotation);
    }
}
