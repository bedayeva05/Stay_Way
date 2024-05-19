using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMode : MonoBehaviour
{
    public GameObject chooseMenuUI;
    public void PlayerControlFreeze()
    {
        GetComponent<PlayerController>().enabled = !GetComponent<PlayerController>().enabled;
        GetComponent<CameraRotation>().enabled = !GetComponent<CameraRotation>().enabled;
    }
    public void EnableChooseMenuUI()
    {
        chooseMenuUI.SetActive(true);
    }
    public void DisableChooseMenuUI()
    {
        chooseMenuUI.SetActive(false);
    }
}
