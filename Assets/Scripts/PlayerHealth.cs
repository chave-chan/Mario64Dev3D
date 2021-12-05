using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private const float InitHealth = 100.0f;
    private float _currentHealth;
    public UnityEvent<float, float> healthChanged;
    private int lifeTotal = 3;

    void Start()
    {
        _currentHealth = InitHealth;
    }

    public void ReceiveDamage(float damage)
    {
        animator.SetTrigger("Damage");
        _currentHealth -= damage;
        healthChanged.Invoke(_currentHealth, InitHealth);
        gameObject.GetComponent<MarioPlayerController>().getHit();
    }

    public float GetInitHealth()
    {
        return InitHealth;
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

    public void completeHeal()
    {
        _currentHealth = InitHealth;
        healthChanged.Invoke(_currentHealth, InitHealth);
    }

    public void Revive()
    {
        lifeTotal--;
    }

    public int getLifeTotal()
    {
        return lifeTotal;
    }
}