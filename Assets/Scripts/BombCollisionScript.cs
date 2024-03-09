using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollisionScript : MonoBehaviour
{
    public BombObstacleScript parentController;
    void OnCollisionEnter(Collision collision)
    {
        parentController.BombHasExploded();
    }
}