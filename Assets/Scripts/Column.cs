using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private float _currentAngle;

    public void RotateColumn()
    {
        _currentAngle = transform.eulerAngles.y;
        while (transform.eulerAngles.y != _currentAngle + 90)
        {
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }

    }
}
