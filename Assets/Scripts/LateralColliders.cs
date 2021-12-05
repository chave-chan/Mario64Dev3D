using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralColliders : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float initHealth = other.GetComponent<PlayerHealth>().GetInitHealth();
            other.GetComponent<PlayerHealth>().ReceiveDamage(initHealth / 8);
        }
    }
}