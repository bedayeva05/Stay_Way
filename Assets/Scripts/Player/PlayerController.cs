using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpforce;
    public float walkingSpeed;
    public float runningSpeed;

    public float maxStamina;
    public float staminaDepletionRate;
    public float staminaRecoveryRate;

    private float _currentSpeed;
    private float _currentStamina;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;

    private bool shouldTeleport = false;
    private bool isRunning = false;

    private Vector3 teleportTarget = Vector3.zero;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _currentSpeed = walkingSpeed;
        _currentStamina = maxStamina;
    }
    void Update()
    {
        StaminaUpdate();
        MovementUpdate();
        JumpUpdate();
    }
    void FixedUpdate()
    {
        if (!shouldTeleport)
        {
            MovementFixedUpdate();
            JumpFixedUpdate();
        }
        else
        {
            transform.position = teleportTarget;
            shouldTeleport = false;
        }
    }
    private void StaminaUpdate()
    {
        if (isRunning && _currentStamina > 0)
        {
            _currentStamina -= staminaDepletionRate * Time.deltaTime;
            if (_currentStamina <= 0)
            {
                _currentSpeed = walkingSpeed;
                _currentStamina = 0;
                isRunning = false;
            }
        }
        else if (!isRunning && _currentStamina < maxStamina)
        {
            _currentStamina += staminaRecoveryRate * Time.deltaTime;
            if (_currentStamina > maxStamina)
            {
                _currentStamina = maxStamina;
            }
        }
    }
    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.LeftShift) && _currentStamina > 0)
        {
            isRunning = true;
            _currentSpeed = runningSpeed;
            _currentStamina -= staminaDepletionRate * Time.deltaTime;
            if (_currentStamina <= 0)
            {
                _currentStamina = 0;
                isRunning = false;
                _currentSpeed = walkingSpeed; 
            }
        }
        else
        {
            isRunning = false;
            _currentSpeed = walkingSpeed; 
            if (_currentStamina < maxStamina)
            {
                _currentStamina += staminaRecoveryRate * Time.deltaTime;
                if (_currentStamina > maxStamina)
                {
                    _currentStamina = maxStamina;
                }
            }
        }
    }
    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpforce;
        }
    }
    private void MovementFixedUpdate()
    {
        _characterController.Move(_moveVector * _currentSpeed * Time.deltaTime);
    }

    private void JumpFixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
    public void TriggerTeleport(Transform target)
    {
        teleportTarget = target.position;
        shouldTeleport = true; 
    }
}