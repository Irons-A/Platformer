using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerVariablesHandler>(out PlayerVariablesHandler pvh))
        {
            pvh.AddScore(_value);
            Destroy(gameObject);
        }
    }
}
