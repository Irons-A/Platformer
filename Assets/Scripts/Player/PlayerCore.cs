using UnityEngine;

[RequireComponent(typeof(PlayerWallet))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerCollisionsChecker))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerFlipper))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerAttacker))]
public class PlayerCore : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 6f;
    [SerializeField] private float _jumpHeight = 14f;
    
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_playerInput.DirectionX * _movementSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_playerInput.IsJumping)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
        }
    }
}
