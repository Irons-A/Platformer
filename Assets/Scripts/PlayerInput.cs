using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const KeyCode JumpKey = KeyCode.UpArrow;
    public const string HorizontalAxis = "Horizontal";

    public bool _isJumping { get; private set; }
    public float _movementAxisInputValue { get; private set; }

    private PlayerCollisionsChecker _collisionsChecker;

    private void Awake()
    {
        _collisionsChecker = GetComponent<PlayerCollisionsChecker>();
    }

    private void Update()
    {
        _isJumping = (Input.GetKeyDown(JumpKey) && _collisionsChecker._isGrounded);
        _movementAxisInputValue = Input.GetAxis(HorizontalAxis);
    }
}
