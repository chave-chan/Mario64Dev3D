using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralColliders : MonoBehaviour
{
    [SerializeField] private float initTimeOfDamage;
    public float timeOfDamage = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && timeOfDamage <= 0f)
        {
            float initHealth = other.GetComponent<PlayerHealth>().GetInitHealth();
            other.GetComponent<PlayerHealth>().ReceiveDamage(initHealth / 8);
            timeOfDamage = initTimeOfDamage;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && timeOfDamage <= 0f)
        {
            float initHealth = other.GetComponent<PlayerHealth>().GetInitHealth();
            other.GetComponent<PlayerHealth>().ReceiveDamage(initHealth / 8);
            timeOfDamage = initTimeOfDamage;
        }
    }

    private void Update()
    {
        timeOfDamage -= Time.deltaTime;
    }
}