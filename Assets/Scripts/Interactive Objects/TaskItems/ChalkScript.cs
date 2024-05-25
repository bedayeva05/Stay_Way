using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChalkScript : MonoBehaviour
{
    public UnityEvent action;
    public bool destroyAfterCollected = true;

    public GameObject buttonIcon;

    private const KeyCode ButtonToPress = KeyCode.F;

    private bool _playerIsNearby;

    private Transform _playerTransform;
    private PlayerProgress _playerProgress;
    private InteractiveMode _playerUI;

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
        _playerProgress.SetChalk();
        _playerUI.ChalkCollected();
        if (!destroyAfterCollected) return;
        Destroy(gameObject);
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
        if (other.gameObject.GetComponent<PlayerProgress>().DoorIsOpened)
        {
            _playerIsNearby = true;
            _playerTransform = other.transform;
            _playerProgress = other.GetComponent<PlayerProgress>();
            _playerUI = other.GetComponent<InteractiveMode>();
            buttonIcon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerController>()) return;
        _playerIsNearby = false;
        _playerTransform = null;
        buttonIcon.SetActive(false);
    }
}
