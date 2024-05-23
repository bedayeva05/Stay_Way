using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] Light _flashLight;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _flashLight.enabled = !_flashLight.enabled;
        }
    }
}
