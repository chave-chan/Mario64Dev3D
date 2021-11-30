using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const int initHealth = 8;
    private int currentHealth;

    void Start()
    {
        currentHealth = initHealth;
    }

    public void ReceiveDamage()
    {
        currentHealth--;
    }

    public void AddHealth()
    {
        currentHealth++;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void LateUpdate()
    {
        if (currentHealth <= 0)
        {
            gameObject.GetComponent<Player>().Die();
        }
    }
}
