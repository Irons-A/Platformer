using UnityEngine;

public class Medpack : MonoBehaviour
{
    [field: SerializeField] public float HealthAmount { get; private set; } = 2;

    public void CommandDestruction()
    {
        Destroy(gameObject);
    }
}
