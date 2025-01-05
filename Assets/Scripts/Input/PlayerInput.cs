using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const KeyCode JumpKey = KeyCode.UpArrow;
    public const KeyCode AttackKey = KeyCode.Space;
    public const string HorizontalAxis = "Horizontal";

    private PlayerCollisionsChecker _collisionsChecker;
    private PlayerAttacker _attacker;

    public bool IsJumping { get; private set; }
    public float DirectionX { get; private set; }

    private void Awake()
    {
        _collisionsChecker = GetComponent<PlayerCollisionsChecker>();
        _attacker = GetComponent<PlayerAttacker>();
    }

    private void Update()
    {
        IsJumping = (Input.GetKey(JumpKey) && _collisionsChecker.IsGrounded);
        DirectionX = Input.GetAxis(HorizontalAxis);

        if (Input.GetKeyDown(AttackKey))
        {
            _attacker.Attack();
        }
    }
}
