using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coins;

    public void CollectCoin(int value)
    {
        _coins += value;
    } 
}
