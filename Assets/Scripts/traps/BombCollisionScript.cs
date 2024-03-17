using UnityEngine;

public class BombCollisionScript : MonoBehaviour
{
    public BombTrapScript parentController;
    
    void OnTriggerEnter(Collider other)
    {
        parentController.BombHasExploded();
    }
    
    void OnCollisionEnter(Collision other)
    {
        parentController.BombHasExploded();
    }
}