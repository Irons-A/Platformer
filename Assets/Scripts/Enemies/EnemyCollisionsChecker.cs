using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyCollisionsChecker : MonoBehaviour
{
    public const int PlayerLayerMask = 1 << 6;

    private EnemyHealth _enemyHealth;
    private EnemyMover _enemyMover;

    [SerializeField] private float _sightLength = 150f;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _sightLength, PlayerLayerMask);

        if (hit.collider.TryGetComponent<PlayerCore>(out _))
        {
            _enemyMover.SetStateOfSight(true);

            Debug.Log("Has Sight");
        }
        else
        {
            _enemyMover.SetStateOfSight(false);
        }

        Debug.DrawRay(transform.position, transform.right * _sightLength, Color.red);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Damager damager) && damager.IsAlly == true)
        {
            _enemyHealth.TakeDamage(damager.Damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Damager damager) && damager.IsAlly == true)
        {
            _enemyHealth.TakeDamage(damager.Damage);
        }
    }
}
