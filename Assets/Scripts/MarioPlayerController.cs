using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    private float verticalSpeed = 0.0f;
    private bool onGround;

    private void Update()
    {
        Vector3 movement = Vector3.zero;
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        movement.y += verticalSpeed * Time.deltaTime;
        CollisionFlags cf = characterController.Move(movement);
        if((cf & CollisionFlags.Below) != 0){
            onGround = true;
            verticalSpeed = 0;
        }
        else
        {
            onGround = false;
        }
        animator.SetBool("OnGround", onGround);
    }
}
