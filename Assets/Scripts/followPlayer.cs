using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform targetPosition;
    public Transform targetRotation;
    void LateUpdate()
    {
        transform.position = targetPosition.position;
        transform.LookAt(targetRotation);
    }
}
