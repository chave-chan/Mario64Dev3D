using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const int InitHealth = 8;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = InitHealth;
    }

    public void ReceiveDamage()
    {
        _currentHealth--;
    }

    public int GetCurrentHealth()
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
