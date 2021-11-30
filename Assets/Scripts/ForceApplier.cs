using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    [SerializeField] Rigidbody bridgeRB;
    [SerializeField] float bridgeForce;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Bridge"))
        {
            bridgeRB.AddForceAtPosition(-hit.normal * bridgeForce, hit.point);
        }
    }
}
