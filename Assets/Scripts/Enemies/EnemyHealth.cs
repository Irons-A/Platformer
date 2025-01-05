using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [field: SerializeField] public int Health { get; private set; } = 3;

    private void Update()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
