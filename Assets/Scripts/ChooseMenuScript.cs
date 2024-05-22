using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMenuScript : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            player.GetComponent<InteractiveMode>().PlayerControlFreeze();
        }
    }
}