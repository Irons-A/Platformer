using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EnemyFlipper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private bool _isMovingRight;

    private Rigidbody2D _rigidbody;
    private EnemyFlipper _enemyFlipper;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyFlipper = GetComponent<EnemyFlipper>();
    }

    private void Start()
    {
        _enemyFlipper.FlipCharacter(_isMovingRight);
    }

    private void Update()
    {
        if (transform.position.x >= _rightBorder.position.x)
        {
            _isMovingRight = false;
            _enemyFlipper.FlipCharacter(_isMovingRight);
        }
        else if (transform.position.x <= _leftBorder.position.x)
        {
            _isMovingRight = true;
            _enemyFlipper.FlipCharacter(_isMovingRight);
        }

        if (_isMovingRight)
        {
            _rigidbody.velocity = new Vector2(_movementSpeed, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_movementSpeed, _rigidbody.velocity.y);
        }
    }
}
