using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LaserTrapScript : MonoBehaviour, IGameOverObserver
{
    public List<GameObject> deadlyLasers;
    public List<GameObject> preventionLasers;
    public float pauseBetweenLasersInS = 2f;
    public float laserDurationInS = 5f;

    private static List<Vector3> _initialPlacements;
    private HorizontalMovement _horizontalMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        _horizontalMovementScript = GetComponent<HorizontalMovement>();
        if (_initialPlacements == null)
        {
            _initialPlacements = new List<Vector3>();
            foreach (var spawnObject in GameObject.FindGameObjectsWithTag("Laser Spawns"))
            {
                _initialPlacements.Add(spawnObject.transform.position);
            }

            if (_initialPlacements.Count == 0)
            {
                throw new UnityException("laser trap need at least one spawn point! (with tag Laser Spawns)");
            }
        }

        InitialRandomPlacement();
        StartCoroutine(LaserRoutine());
    }

    private void InitialRandomPlacement()
    {
        int index = Random.Range(0, _initialPlacements.Count);
        transform.SetPositionAndRotation(_initialPlacements[index], transform.rotation);
    }

    private IEnumerator LaserRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(laserDurationInS);
            deadlyLasers.ForEach(laser => laser.SetActive(false));

            //prevention phase while lasers are not deadly
            if (pauseBetweenLasersInS >= 3)
            {
                yield return new WaitForSeconds(pauseBetweenLasersInS - 3);
                for (int i = 0; i < 3; i++)
                {
                    preventionLasers.ForEach(laser => laser.SetActive(true));
                    yield return new WaitForSeconds(0.5f);
                    preventionLasers.ForEach(laser => laser.SetActive(false));
                    yield return new WaitForSeconds(0.33f);
                }
            }
            else
            {
                yield return new WaitForSeconds(pauseBetweenLasersInS);
            }

            deadlyLasers.ForEach(laser => laser.SetActive(true));
        }
    }
    
    public void GameOverNotification()
    {
        _horizontalMovementScript.enabled = false;
        StopAllCoroutines();
    }
}