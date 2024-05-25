using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private PlayerController _player;

    public void TeleportTo(Transform newPosition)
    {
        _player = FindObjectOfType<PlayerController>();
        if (_player != null)
        {
            _player.TriggerTeleport(newPosition);
        }
    }
}
