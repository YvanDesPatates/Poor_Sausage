using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform targetPosition;
    public Transform targetRotation;
    void LateUpdate()
    {
        transform.position = targetPosition.position;
        transform.LookAt(targetRotation);
    }
}
