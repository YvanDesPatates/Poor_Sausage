using UnityEngine;

public class BombCollisionScript : MonoBehaviour
{
    public BombObstacleScript parentController;
    
    void OnTriggerEnter(Collider other)
    {
        parentController.BombHasExploded();
    }
}