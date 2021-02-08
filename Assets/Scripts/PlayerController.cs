using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCotroller : MonoBehaviour
{
    
    [SerializeField]private float _speed = 2f;
    [SerializeField]private float _jumpForce = 2f;
    private GameObject _player;
    private Rigidbody _playerRg;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _playerRg = _player.GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float horValue = Input.GetAxis("Horizontal") * _speed;
        float vertValue = Input.GetAxis("Vertical") * _speed;
        Vector3 movementVector = new Vector3(horValue,_playerRg.velocity.y,vertValue);
        _playerRg.velocity = movementVector;
    }

    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed");
            _playerRg.velocity = new Vector3(_playerRg.velocity.x, _jumpForce, _playerRg.velocity.z);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    
}
