using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerVariablesHandler))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public const KeyCode JumpKey = KeyCode.UpArrow;

    [SerializeField] private float _movementSpeed = 6f;
    [SerializeField] private float _jumpHeight = 14f;
    
    private Rigidbody2D _theRB;
    private SpriteRenderer _theSR;
    private Animator _animator;
    private bool _isGrounded = true;
    
    private float _movementVelocity;

    private void Awake()
    {
        _theRB = GetComponent<Rigidbody2D>();
        _theSR = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ProcessAnimations();
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        _theRB.velocity = new Vector2(moveInput * _movementSpeed, _theRB.velocity.y);

        if (moveInput > 0)
        {
            _theSR.flipX = false;
        }
        else if (moveInput < 0)
        {
            _theSR.flipX = true;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(JumpKey) && _isGrounded)
        {
            _theRB.velocity = new Vector2(_theRB.velocity.x, _jumpHeight);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Solid"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Solid"))
        {
            _isGrounded = false;
        }
    }

    private void ProcessAnimations()
    {
        _movementVelocity = Math.Abs(_theRB.velocity.x);
        _animator.SetFloat("MoveSpeed", _movementVelocity);
    }
}
