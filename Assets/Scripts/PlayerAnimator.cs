using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public readonly int MoveSpeed = Animator.StringToHash(nameof(MoveSpeed));

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private SpriteRenderer _spriteRenderer;

    private float _movementVelocity;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _movementVelocity = Math.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(MoveSpeed, _movementVelocity);

        if (_playerInput._movementAxisInputValue > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_playerInput._movementAxisInputValue < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
