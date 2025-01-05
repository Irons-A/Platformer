using UnityEngine;

public class Damager : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public bool IsAlly { get; private set; }

    public void SetParameters(int damage, bool isAlly)
    {
        Damage = damage;
        IsAlly = isAlly;
    }
}
