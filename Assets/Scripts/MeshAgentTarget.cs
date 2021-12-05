using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshAgentTarget : MonoBehaviour
{
    [Header("EXCLUSIVE NAV")]
    [SerializeField] private NavMeshAgent _Agent;
    [SerializeField] private Transform _Player;

    [Header("NAVIGATION POINTS")]
    [SerializeField] private Transform originPoint;
    [SerializeField] private Transform destinationPoint;

    [Header("ANIMATION")]
    [SerializeField] private Animator _animator;
    [SerializeField] private float lerpTime = 1;

    public void Patrol()
    {
        if (transform.position.x.CompareTo(destinationPoint.position.x) == 0 && transform.position.z.CompareTo(destinationPoint.position.z) == 0)
        {
            (destinationPoint, originPoint) = (originPoint, destinationPoint);
        }
        _Agent.destination = destinationPoint.position;
    }

    public void Chase()
    {
        _Agent.destination = _Player.position;
    }

    public void Alert()
    {
        _Agent.destination = transform.position; 
        transform.Rotate(new Vector3(0f, 100f, 0) * Time.deltaTime);
        _Agent.updateRotation = true;
    }

    public void Attack()
    {
    }
}