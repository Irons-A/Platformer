using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _lifetime = 0.2f;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
        transform.position += transform.right * _movementSpeed * Time.deltaTime;
    }
}
