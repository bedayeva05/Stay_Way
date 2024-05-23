using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColumnButton : MonoBehaviour
{
    public UnityEvent action;
    public GameObject buttonIcon;

    private const KeyCode ButtonToPress = KeyCode.F;

    private bool _playerIsNearby;
    private bool _playerHasNeededLevel = false;
    private Transform _playerTransform;

    private void Update()
    {
        UpdatePressButton();
        UpdateButtonIconRotation();
    }
    private void UpdatePressButton()
    {
        if (!_playerIsNearby) return;
        if (!Input.GetKeyDown(ButtonToPress)) return;
        if (!_playerHasNeededLevel)
        { 
            action?.Invoke(); 
        }
    }
    private void UpdateButtonIconRotation()
    {
        if (_playerTransform != null && _playerHasNeededLevel)
        {
            Vector3 directionToPlayer = _playerTransform.position - buttonIcon.transform.position;
            directionToPlayer.y = 0;
            buttonIcon.transform.rotation = Quaternion.LookRotation(directionToPlayer) * Quaternion.Euler(0, 180, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerController>()) return;
        _playerHasNeededLevel = other.GetComponent<PlayerProgress>().WholeBook;
        if (_playerHasNeededLevel)
        {
            _playerIsNearby = true;
            _playerTransform = other.transform;
            buttonIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerController>()) return;
        if (_playerHasNeededLevel)
        {
            _playerIsNearby = false;
            _playerTransform = null;
            buttonIcon.SetActive(false);
        }
    }
}
