using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 5;

    [field: SerializeField] public int Health { get; private set; } = 5;

    private void Update()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
        else if (Health > _maxHealth)
        {
            Health = _maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void RestoreHealth(int health)
    {
        Health += health;
    }    
}
