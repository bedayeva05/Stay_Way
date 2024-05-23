using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private GameObject _player;

    public void TeleportTo(Transform newPosition)
    {
        if (_player != null)
        {
            _player.GetComponent<PlayerController>().TriggerTeleport(newPosition);
        }
    }
}
