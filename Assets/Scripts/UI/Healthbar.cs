using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private BaseHealth _health;
    [SerializeField] private Camera _camera;

    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.ValueChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= DisplayHealth;
    }

    private void Update()
    {
        transform.rotation = _camera.transform.rotation;
    }

    private void DisplayHealth(float currenHealth, float maxHealth)
    {
        _healthSlider.value = currenHealth / maxHealth;
    }
}
