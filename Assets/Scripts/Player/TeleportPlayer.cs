using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;

    public void TeleportTo(Transform newPosition)
    {
        if (player != null)
        {
            player.GetComponent<PlayerController>().TriggerTeleport(newPosition);
        }
    }
}
