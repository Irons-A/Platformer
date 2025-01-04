using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const KeyCode JumpKey = KeyCode.UpArrow;
    public const string HorizontalAxis = "Horizontal";

    public bool IsJumping { get; private set; }
    public float DirectionX { get; private set; }

    private PlayerGroundChecker _collisionsChecker;

    private void Awake()
    {
        _collisionsChecker = GetComponent<PlayerGroundChecker>();
    }

    private void Update()
    {
        IsJumping = (Input.GetKeyDown(JumpKey) && _collisionsChecker.IsGrounded);
        DirectionX = Input.GetAxis(HorizontalAxis);
    }
}
