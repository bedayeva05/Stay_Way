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
    //public bool needsCondition;

    public GameObject buttonIcon;

    private const KeyCode ButtonToPress = KeyCode.F;

    private bool _playerIsNearby;


    private void Update()
    {
        UpdatePressButton();
    }
    private void UpdatePressButton()
    {
        if (!_playerIsNearby) return;
        if (!Input.GetKeyDown(ButtonToPress)) return;
        action?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerController>()) return;
        _playerIsNearby = true;
        buttonIcon.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerController>()) return;
        _playerIsNearby = false;
        buttonIcon.SetActive(false);
    }

}
