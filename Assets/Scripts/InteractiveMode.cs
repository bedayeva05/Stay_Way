using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMode : MonoBehaviour
{
    public GameObject InteractiveMapUI;

    public void TogglePlayerScripts()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        InteractiveMapUI.SetActive(true);
    }
}
