using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openAngle = 90f;
    public float closeAngle = 0f;
    public float speed = 100f;
    private bool isOpen = false;
    private Quaternion initialRotation;
    private Quaternion openRotation;
    private Quaternion closeRotation;
    private new BoxCollider collider;
    void Start()
    {
        initialRotation = transform.rotation;
        collider = GetComponent<BoxCollider>();
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z + openAngle);
        closeRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z + closeAngle);
    }
    public void ToggleDoor()
    {
        collider.enabled = false;
        isOpen = !isOpen;
        enabled = true;
    }
    void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closeRotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
        {
            transform.rotation = targetRotation;
            enabled = false;
            collider.enabled = true;
        }
    }
}
