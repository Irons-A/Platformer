using UnityEngine;

public class Damager : MonoBehaviour
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public bool IsAlly { get; private set; }

    public void SetParameters(float damage, bool isAlly)
    {
        Damage = damage;
        IsAlly = isAlly;
    }
}
