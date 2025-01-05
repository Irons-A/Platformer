using UnityEngine;

public class PlayerCollisionsChecker : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Ground>(out _))
        {
            IsGrounded = true;
        }
        else if (collision.collider.TryGetComponent(out Damager damager) && damager.IsAlly == false)
        {
            _playerHealth.TakeDamage(damager.Damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Damager damager) && damager.IsAlly == false)
        {
            _playerHealth.TakeDamage(damager.Damage);
        }
        else if (collision.TryGetComponent(out Medpack medpack))
        {
            _playerHealth.RestoreHealth(medpack.HealthAmount);
            medpack.CommandDestruction();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Ground>(out _))
        {
            IsGrounded = false;
        }
    }
}
