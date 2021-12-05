using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformVector(Vector3.forward), out hit, 10f))
        {
            _enemy.SetPlayerInRange(hit.transform.gameObject.CompareTag("Player"));
        }

        else if (Physics.Raycast(transform.position, transform.TransformVector(Vector3.forward), out hit, 20f))
        {
            _enemy.SetPlayerDetected(hit.transform.gameObject.CompareTag("Player"));
        }
    }
}