using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public readonly int MoveSpeed = Animator.StringToHash(nameof(MoveSpeed));

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _movementVelocity;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movementVelocity = Math.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(MoveSpeed, _movementVelocity);
    }
}
