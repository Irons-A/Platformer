using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _value = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Wallet>(out Wallet wallet))
        {
            wallet.CollectCoin(_value);
            Destroy(this.gameObject);
        }
    }
}
