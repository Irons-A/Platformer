using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private float _score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _score += coin.Value;
            coin.MarkAsCollected();
        }
    }
}
