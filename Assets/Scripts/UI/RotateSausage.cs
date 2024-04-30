using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSausage : MonoBehaviour
{
    public float rotationSpeed = 10;
    public float timeBetweenChangigRotationDirInS = 2;
    
    private bool _rotateForward = true;

    private void Start()
    {
        StartCoroutine(ChangeRotationDirection());
    }

    // Update is called once per frame
    void Update()
    {
        var rotateDirection = _rotateForward ? Vector3.forward : Vector3.back;
        transform.RotateAround(transform.position, rotateDirection,  rotationSpeed * Time.deltaTime);
    }
    
    IEnumerator ChangeRotationDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenChangigRotationDirInS);
            _rotateForward = !_rotateForward;
        }
    }
}
