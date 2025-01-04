using UnityEngine;

public class PlayerCollisionsChecker : MonoBehaviour
{
    public bool _isGrounded { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<SolidObject>(out _))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<SolidObject>(out _))
        {
            _isGrounded = false;
        }
    }
}
