using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private const float InitHealth = 100.0f;
    private float _currentHealth;
    public UnityEvent<float, float> healthChanged;

    void Start()
    {
        _currentHealth = InitHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReceiveDamage(InitHealth / 8);
        }
    }

    public void ReceiveDamage(float damage)
    {
        _currentHealth -= damage;
        healthChanged.Invoke(_currentHealth, InitHealth);
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    private void LateUpdate()
    {
        if (_currentHealth <= 0)
        {
            gameObject.GetComponent<Player>().Die();
        }
    }
}