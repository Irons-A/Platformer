using System.Xml.Serialization;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyFlipper))]
[RequireComponent(typeof(EnemyCollisionsChecker))]
public class EnemyCore : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _chasingSpeed = 5f;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private bool _isMovingRight;
    private bool _hasSightOfPlayer;
    private float _currentMovementSpeed;

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
        if (_hasSightOfPlayer == false)
        {
            _currentMovementSpeed = _movementSpeed;

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
        }
        else
        {
            _currentMovementSpeed = _chasingSpeed;
        }

        if (_isMovingRight)
        {
            _rigidbody.velocity = new Vector2(_currentMovementSpeed, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_currentMovementSpeed, _rigidbody.velocity.y);
        }
    }

    public void SetStateOfSight(bool hasSight)
    {
        _hasSightOfPlayer = hasSight;
    }
}
