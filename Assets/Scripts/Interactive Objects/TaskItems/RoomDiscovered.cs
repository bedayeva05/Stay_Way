using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDiscovered : MonoBehaviour
{
    private PlayerProgress _playerProgress;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerController>()) return;
        /*if (other.gameObject.GetComponent<PlayerProgress>().DoorIsOpened)
        {
            
        }*/
        _playerProgress = other.GetComponent<PlayerProgress>();
        _playerProgress.SetRoomDiscovered();
    }
}
