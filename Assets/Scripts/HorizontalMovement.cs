using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float speed = 3;
    public float minX = 0;
    public float maxX = 100;

    private Vector3 _direction = Vector3.left;
    // Update is called once per frame
    void Update()
    {
        // go left if beyond maxX, right if before minX and keep actual direction between
        _direction = transform.position.x <= minX ? Vector3.right :
            transform.position.x >= maxX ? Vector3.left : _direction;
        
        transform.Translate(speed * Time.deltaTime * _direction);
    }
}
