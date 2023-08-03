using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidBody2d;
    private Animator _animator;
    private SpriteRenderer _spriterenderer;
    [SerializeField] private int _coins;
    private float _speed = 5f;
    private float _jumpStrength = 8f;
    private float _runningAnimationThreshhold = 0.02f;
    private int RunBoolHash = Animator.StringToHash("isRunning");
    private int JumpTriggerHash = Animator.StringToHash("Jump");


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
            _animator.SetBool(RunBoolHash, true);
        }
        else
        {
            _animator.SetBool(RunBoolHash, false);
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
            _animator.SetTrigger(JumpTriggerHash);
        }
    }

    public void CollectCoin(int value)
    {
        _coins += value;
    }
}
