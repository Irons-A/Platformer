using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerWallet))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    public const KeyCode JumpKey = KeyCode.UpArrow;
    public const string HorizontalAxis = "Horizontal";

    public readonly int MoveSpeed = Animator.StringToHash(nameof(MoveSpeed));

    [SerializeField] private float _movementSpeed = 6f;
    [SerializeField] private float _jumpHeight = 14f;
    
    private Rigidbody2D _theRB;
    private SpriteRenderer _theSR;
    private Animator _animator;
    private bool _isGrounded = true;
    private float _movementAxisInputValue;
    private bool _isJumping;
    
    private float _movementVelocity;

    private void Awake()
    {
        _theRB = GetComponent<Rigidbody2D>();
        _theSR = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movementAxisInputValue = Input.GetAxis(HorizontalAxis);

        if (Input.GetKeyDown(JumpKey) && _isGrounded)
        {
            _isJumping = true;
        }
        else
        {
            _isJumping = false;
        }

        ProcessAnimations();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _theRB.velocity = new Vector2(_movementAxisInputValue * _movementSpeed, _theRB.velocity.y);

        if (_movementAxisInputValue > 0)
        {
            _theSR.flipX = false;
        }
        else if (_movementAxisInputValue < 0)
        {
            _theSR.flipX = true;
        }
    }

    private void Jump()
    {
        if (_isJumping)
        {
            _theRB.velocity = new Vector2(_theRB.velocity.x, _jumpHeight);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<SolidObject>(out _))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<SolidObject>(out _))
        {
            _isGrounded = false;
        }
    }

    private void ProcessAnimations()
    {
        _movementVelocity = Math.Abs(_theRB.velocity.x);
        _animator.SetFloat(MoveSpeed, _movementVelocity);
    }
}
