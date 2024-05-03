using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<InteractiveMode>().PlayerControlFreeze();
            FindObjectOfType<InteractiveMode>().ShowingTheMap();
        }
    }
}
