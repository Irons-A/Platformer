using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 3f;
    private int _health = 5;
    private Coroutine _controlMovement;
    [SerializeField] private bool _isMovingRight = true;
    private WaitForSeconds _changeDirectionInterval = new WaitForSeconds(2);

    private void Start()
    {
        _controlMovement = StartCoroutine(ControlMovement());
    }

    private void Update()
    {
        if (_isMovingRight)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }
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
}
