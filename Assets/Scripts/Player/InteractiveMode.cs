using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMode : MonoBehaviour
{
    public void PlayerControlFreeze()
    {
        GetComponent<PlayerController>().enabled = !GetComponent<PlayerController>().enabled;
        GetComponent<CameraRotation>().enabled = !GetComponent<CameraRotation>().enabled;
    }
}
