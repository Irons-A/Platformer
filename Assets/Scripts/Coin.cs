using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> IsCollected;

    [SerializeField] public int _value { get; private set; } = 10;

    public void MarkAsCollected()
    {
        IsCollected?.Invoke(this);
    }
}
