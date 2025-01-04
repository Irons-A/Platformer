using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private bool _isMovingRight = true;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprireRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprireRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (transform.position.x >= _rightBorder.position.x)
        {
            _isMovingRight = false;
        }
        else if (transform.position.x <= _leftBorder.position.x)
        {
            _isMovingRight = true;
        }

        if (_isMovingRight)
        {
            _rigidbody.velocity = new Vector2(_movementSpeed, _rigidbody.velocity.y);
            _sprireRenderer.flipX = true;
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_movementSpeed, _rigidbody.velocity.y);
            _sprireRenderer.flipX = false;
        }
    }
}
