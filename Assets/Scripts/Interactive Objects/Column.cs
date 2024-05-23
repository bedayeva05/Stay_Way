using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public float rotationSpeed = 30f;
    private float _targetRotationAngle = 90f;
    private float _startRotationAngle;

    private bool isRotating = false;
    private float currentRotationAngle = 0f;

    void Update()
    {
        if (isRotating)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            if (currentRotationAngle + rotationStep > _targetRotationAngle)
            {
                rotationStep = _targetRotationAngle - currentRotationAngle;
                currentRotationAngle = _targetRotationAngle; 
            }
            else
            {
                currentRotationAngle += rotationStep;
            }

            transform.Rotate(Vector3.back, rotationStep);

            if (currentRotationAngle >= _targetRotationAngle)
            {
                isRotating = false;
                currentRotationAngle = 0f;
            }
        }
    }

    public void StartRotation()
    {
        _startRotationAngle = transform.rotation.eulerAngles.z;
        isRotating = true;
    }
}
