using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidBody2d;
    private Animator _animator;
    private SpriteRenderer _spriterenderer;
    private float _speed = 5f;
    private float _jumpStrength = 8f;
    private float _runningAnimationThreshhold = 0.02f;
    private int _runBoolHash = Animator.StringToHash("isRunning");
    private int _jumpTriggerHash = Animator.StringToHash("Jump");


    private void Start()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriterenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidBody2d.AddForce(transform.right * _speed * Input.GetAxis("Horizontal"), ForceMode2D.Force);

        if (_rigidBody2d.velocity.magnitude > _runningAnimationThreshhold)
        {
            _animator.SetBool(_runBoolHash, true);
        }
        else
        {
            _animator.SetBool(_runBoolHash, false);
        }

        if (_rigidBody2d.velocity.x< 0)
        {
            _spriterenderer.flipX = true;
        }
        else if (_rigidBody2d.velocity.x > 0)
        {
            _spriterenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidBody2d.AddForce(transform.up * _jumpStrength, ForceMode2D.Impulse);
            _animator.SetTrigger(_jumpTriggerHash);
        }
    }
}
