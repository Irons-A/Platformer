using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{
    private PlayerInput _playerInput;
    private bool _isFlipped = false;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_playerInput.DirectionX > 0 && _isFlipped == true)
        {
            FlipCharacter();
        }
        else if (_playerInput.DirectionX < 0 && _isFlipped == false)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        _isFlipped = !_isFlipped;
        transform.Rotate(0, 180, 0);
    }
}
