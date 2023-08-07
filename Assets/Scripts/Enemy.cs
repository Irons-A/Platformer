using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isMovingRight = true;

    private float _speed = 3f;
    private int _health = 5;
    private Coroutine _controlMovement;
    private WaitForSeconds _changeDirectionInterval = new WaitForSeconds(2);

    private void Start()
    {
        _controlMovement = StartCoroutine(ControlMovement());
    }

    private void Update()
    {
        Move();
    }

    private IEnumerator ControlMovement()
    {
        while (_health > 0)
        {
            _isMovingRight = true;
            yield return _changeDirectionInterval;
            _isMovingRight = false;
            yield return _changeDirectionInterval;
        }
    }

    private void Move()
    {
        int directionDefiner;

        if (_isMovingRight)
        {
            directionDefiner = 1;
        }
        else
        {
            directionDefiner = -1;
        }

        transform.Translate(directionDefiner * _speed * Time.deltaTime, 0, 0);
    }
}
