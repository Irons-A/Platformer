using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private bool _isMovingRight = true;
    private Rigidbody2D _theRB;
    private SpriteRenderer _theSR;

    private void Awake()
    {
        _theRB = GetComponent<Rigidbody2D>();
        _theSR = GetComponent<SpriteRenderer>();
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
            _theRB.velocity = new Vector2(_movementSpeed, _theRB.velocity.y);
            _theSR.flipX = true;
        }
        else
        {
            _theRB.velocity = new Vector2(-_movementSpeed, _theRB.velocity.y);
            _theSR.flipX = false;
        }
    }
}
