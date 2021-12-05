using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertArea : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           _enemy.SetPlayerHeard(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemy.SetPlayerHeard(false);
        }
    }
}
