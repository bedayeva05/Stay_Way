using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEditor;
[ExecuteInEditMode]
public class TeleportButton : MonoBehaviour
{
    public UnityEvent action;
    public GameObject buttonIcon;

    public int targetSceneIndex;
    public int targetTeleportPointIndex;


    private const KeyCode ButtonToPress = KeyCode.F;

    private bool _playerIsNearby;

    private Transform _playerTransform;
    private GameObject _player;

    private void Update()
    {
        UpdatePressButton();
        UpdateButtonIconRotation();
    }

    private void UpdatePressButton()
    {
        if (!_playerIsNearby) return;
        if (!Input.GetKeyDown(ButtonToPress)) return;

        TeleportManager.Instance.TeleportPlayer(targetSceneIndex, targetTeleportPointIndex);
        //StartCoroutine(LoadAndTeleport(targetSceneIndex, targetTeleportPointIndex));
    }

    private void UpdateButtonIconRotation()
    {
        if (_playerTransform != null)
        {
            Vector3 directionToPlayer = _playerTransform.position - buttonIcon.transform.position;
            directionToPlayer.y = 0;
            buttonIcon.transform.rotation = Quaternion.LookRotation(directionToPlayer) * Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerController>()) return;
        _player = other.gameObject;
        _playerIsNearby = true;
        _playerTransform = other.transform;
        buttonIcon.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerController>()) return;
        _playerIsNearby = false;
        _playerTransform = null;
        buttonIcon.SetActive(false);
    }
}