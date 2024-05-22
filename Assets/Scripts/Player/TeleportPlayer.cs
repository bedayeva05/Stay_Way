using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private GameObject _player;

    public void TeleportTo(Transform newPosition)
    {
        _player = FindObjectOfType<PlayerController>().gameObject;
        if (_player != null)
        {
            _player.GetComponent<PlayerController>().TriggerTeleport(newPosition);
        }
    }
}
