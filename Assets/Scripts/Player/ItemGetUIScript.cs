using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetUIScript : MonoBehaviour
{
    public InteractiveMode playerUI;
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            playerUI.PlayerControlFreeze();
            gameObject.SetActive(false);
        }
    }
}
