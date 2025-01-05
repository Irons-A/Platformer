using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Damager _projectilePrefab;
    [SerializeField] private Transform _firePoint;

    public void Attack ()
    {
        Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
    }
}
