using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PlayerHealth health;
    [SerializeField] private int coins = 0;

    public void Die()
    {
        animator.SetTrigger("Death");
        gameManager.GameOver();
    }
}
