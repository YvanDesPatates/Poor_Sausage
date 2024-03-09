using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollisionScript : MonoBehaviour
{
    public BombObstacleScript parentController;
    
    void OnTriggerEnter(Collider other)
    {
        parentController.BombHasExploded();
    }
}