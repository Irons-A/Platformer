using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_playerInput.DirectionX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_playerInput.DirectionX < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
