using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> IsCollected;

    [SerializeField] public int value { get; private set; } = 10;

    public void MarkAsCollected()
    {
        IsCollected?.Invoke(this);
    }
}
