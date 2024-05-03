using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpforce;
    public float speed;
    
    private Vector3 _moveVector;
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    
    private bool shouldTeleport = false;
    private Vector3 teleportTarget = Vector3.zero;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovementUpdate();
        JumpUpdate();

    }

    void FixedUpdate()
    {
        MovementFixedUpdate();
        JumpFixedUpdate();
        if (shouldTeleport)
        {
            transform.position = teleportTarget;
            shouldTeleport = false; 
        }
    }

    private void MovementUpdate()
    {
        //Movement
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
    }

    private void JumpUpdate()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpforce;
        }
    }

    private void MovementFixedUpdate()
    {
        //Movement
        _characterController.Move(_moveVector * speed * Time.deltaTime);

    }

    private void JumpFixedUpdate()
    {
        //Fall and jump
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