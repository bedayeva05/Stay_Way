using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#if (UNITY_EDITOR)
using UnityEditor;
[ExecuteInEditMode]
#endif
public class InteractiveButton : MonoBehaviour
{
    public UnityEvent action;
    public GameObject buttonIcon;

    private const KeyCode ButtonToPress = KeyCode.F;

    private bool _playerIsNearby;

    private Transform _playerTransform;

    public void MustDo()
    {
        action?.Invoke();
    }
    private void Update()
    {
        UpdatePressButton();
        UpdateButtonIconRotation();
    }
    private void UpdatePressButton()
    {
        if (!_playerIsNearby) return;
        if (!Input.GetKeyDown(ButtonToPress)) return;
        action?.Invoke();
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
