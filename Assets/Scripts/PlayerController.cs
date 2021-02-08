using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    
    [SerializeField]private float _speed = 2f;
    [SerializeField]private float _jumpForce = 2f;
    private Rigidbody _playerRg;
    private Animator _animator;
    private bool _isTookOff;
    public bool IsGrounded;
    private static readonly int State = Animator.StringToHash("State");
    private static readonly int TookOff = Animator.StringToHash("Took_off");
    private static readonly int IsJumping = Animator.StringToHash("Is_Jumping");

    void Start()
    {
        _playerRg = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horValue = Input.GetAxis("Horizontal") * _speed;
        float vertValue = Input.GetAxis("Vertical") * _speed;
        Vector3 movementVector = new Vector3(horValue,_playerRg.velocity.y,vertValue);
        if (movementVector.magnitude == 0)
        {
            _animator.SetInteger(State,2);
        }
        else
        {
            _animator.SetInteger(State,1);
            _playerRg.velocity = movementVector;
        }
    }

    void Update()
    {
        IsGrounded = CheckIsGrounded();
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _playerRg.velocity = new Vector3(_playerRg.velocity.x, _jumpForce, _playerRg.velocity.z);
            _isTookOff = true;
            _animator.SetTrigger(TookOff);
        }

        if (IsGrounded)
        {
            _animator.SetBool(IsJumping, false);

        }
        else _animator.SetBool(IsJumping, true);
    }

    private bool CheckIsGrounded()
    {
       return Physics.Raycast(transform.position, Vector3.down, 1.1f);
       
    }

    private enum PlayerStates
    { 
        RUN = 1, 
       IDLE = 2,
    }
}
