using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> IsCollected;

    [field: SerializeField] public float Value { get; private set; } = 10;

    public void MarkAsCollected()
    {
        IsCollected?.Invoke(this);
    }
}
