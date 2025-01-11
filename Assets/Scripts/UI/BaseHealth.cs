using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 5;

    public event Action<float, float> ValueChanged;

    [field: SerializeField] public float Health { get; private set; } = 5;

    private void Start()
    {
        ValueChanged?.Invoke(Health, _maxHealth);
    }

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

    public void TakeDamage(float damage)
    {
        Health -= damage;
        ValueChanged?.Invoke(Health, _maxHealth);
    }

    public void RestoreHealth(float health)
    {
        Health += health;
        ValueChanged?.Invoke(Health, _maxHealth);
    }
}
