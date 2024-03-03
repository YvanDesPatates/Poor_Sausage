using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 100;
    
    private float _horizontalInput;
    private float _verticalInput;
    private float _horizontalMouseInput;
    
    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalMouseInput = Input.GetAxis("Mouse X");
        
        Vector3 direction = new Vector3(_horizontalInput, 0, _verticalInput);
        
        transform.Translate(speed * Time.deltaTime * direction);
        transform.Rotate(Vector3.up, _horizontalMouseInput * rotationSpeed * Time.deltaTime);
    }
}
