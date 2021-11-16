using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [Range(0,2)]
    [SerializeField] private float speed;

    void Update()
    {
        animator.SetFloat("Speed", speed);
    }
}
