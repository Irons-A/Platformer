using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampField : MonoBehaviour
{
    [SerializeField] private float _searchRadius = 2;
    [SerializeField] private float _recievedHealth = 1;
    [SerializeField] private float _dealtDamage = 1;
    [SerializeField] private float _triggeringFrequency = 1;
    [SerializeField] private float _activeTime = 6;
    [SerializeField] private float _rechargeTime = 4;

    [SerializeField] private PlayerInput _input;
    [SerializeField] private BaseHealth _userHealth;
    [SerializeField] private Slider _statusBar;
    [SerializeField] private GameObject _vampField;
    [SerializeField] private GameObject _user;

    private WaitForSeconds _timeMeasurementUnit;
    private bool _isFieldReady = true;
    private Coroutine _currentRoutine;

    private void OnEnable()
    {
        _input.IsActivatingVampField += ActivateVampField;
    }

    private void OnDisable()
    {
        _input.IsActivatingVampField -= ActivateVampField;
    }

    private void Start()
    {
        _timeMeasurementUnit = new WaitForSeconds (_triggeringFrequency);
    }

    private void Update()
    {
        transform.position = _user.transform.position;
    }

    private void ActivateVampField()
    {
        if (_isFieldReady)
        {
            _isFieldReady = false;
            _vampField.SetActive(true);

            if (_currentRoutine != null)
            {
                StopCoroutine(_currentRoutine);
            }

            _currentRoutine = StartCoroutine(WorkingRoutine());
        }
    }

    private EnemyHealth ScanForTargets()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), _searchRadius);

        EnemyHealth closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D hit in hits)
        {
            float distance = Vector3.Distance(transform.position, hit.transform.position);

            if (hit.gameObject.TryGetComponent(out EnemyHealth enemy) && distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private IEnumerator WorkingRoutine()
    {
        float remainingTime = _activeTime;

        while (remainingTime > 0)
        {
            EnemyHealth closestEnemy = ScanForTargets();

            if (closestEnemy != null)
            {
                closestEnemy.TakeDamage(_dealtDamage);
                _userHealth.RestoreHealth(_recievedHealth);
            }

            yield return _timeMeasurementUnit;
            remainingTime -= _triggeringFrequency;
            _statusBar.value = remainingTime / _activeTime;
        }

        _vampField.SetActive(false);
        _currentRoutine = StartCoroutine(RechargeRoutine());
    }

    private IEnumerator RechargeRoutine()
    {
        float elaspedTime = 0;

        while (elaspedTime < _rechargeTime)
        {
            yield return _timeMeasurementUnit;
            elaspedTime += _triggeringFrequency;
            _statusBar.value = elaspedTime / _rechargeTime;
        }

        _isFieldReady = true;
    }
}
