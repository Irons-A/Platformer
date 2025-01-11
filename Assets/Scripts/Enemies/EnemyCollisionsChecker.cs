using UnityEngine;

public class EnemyCollisionsChecker : MonoBehaviour
{
    [SerializeField] private float _sightLength = 150f;

    private EnemyHealth _enemyHealth;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyMover = GetComponent<EnemyMover>();

        transform.rotation = Quaternion.Euler(5, 5, 5);
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right, _sightLength);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent<PlayerCore>(out _))
            {
                _enemyMover.SetStateOfSight(true);

                return;
            }
            else
            {
                _enemyMover.SetStateOfSight(false);
            }
        }

        Debug.DrawRay(transform.position, transform.right * _sightLength, Color.red);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Damager damager) && damager.IsAlly)
        {
            _enemyHealth.TakeDamage(damager.Damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Damager damager) && damager.IsAlly)
        {
            _enemyHealth.TakeDamage(damager.Damage);
        }
    }
}
