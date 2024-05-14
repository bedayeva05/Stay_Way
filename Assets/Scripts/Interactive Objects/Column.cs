using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float targetRotationAngle = 90f;

    private bool isRotating = false;
    private float currentRotationAngle = 0f;

    void Update()
    {
        if (isRotating)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.back, rotationStep);

            currentRotationAngle += rotationStep;

            if (currentRotationAngle >= targetRotationAngle)
            {
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRotationAngle, transform.rotation.eulerAngles.z);

                isRotating = false;
                currentRotationAngle = 0f;
            }
        }
    }

    public void StartRotation()
    {
        isRotating = true;
    }
}
