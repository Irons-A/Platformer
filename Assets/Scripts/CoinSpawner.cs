using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _respawnFrequency = 4f;
    [SerializeField] private List<Coin> _coins;

    private WaitForSeconds _delay;

    private void OnEnable()
    {
        foreach (var item in _coins)
        {
            item.IsCollected += RespawnCoin;
        }
    }

    private void OnDisable()
    {
        foreach (var item in _coins)
        {
            item.IsCollected -= RespawnCoin;
        }
    }

    private void RespawnCoin(Coin coin)
    {
        StartCoroutine(CoinRespawnRoutine(coin));
    }

    private IEnumerator CoinRespawnRoutine(Coin coin)
    {
        _delay = new WaitForSeconds(_respawnFrequency);

        coin.gameObject.SetActive(false);

        yield return _delay;

        coin.gameObject.SetActive(true);
    }
}
