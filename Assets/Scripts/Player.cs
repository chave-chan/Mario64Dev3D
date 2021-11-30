using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerHealth health;
    [SerializeField] private int coins = 0;

    public void Die()
    {
        Debug.Log("PLAYER DIES");
        //TODO: HUD OF DEATH APPEARS
        gameManager.GameOver();
        gameObject.transform.position = spawnPoint.position;
    }
}
