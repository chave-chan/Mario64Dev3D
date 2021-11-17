using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    [Header("Jump")]
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpSpeed;
    private float verticalSpeed = 0.0f;
    private bool onGround;

    private void Update()
    {
        Vector3 movement = Vector3.zero;
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        movement.y += verticalSpeed * Time.deltaTime;
        CollisionFlags cf = characterController.Move(movement);

        if (Input.GetKeyDown(jumpKey) && onGround)
        {
            jump();
        }
        if((cf & CollisionFlags.Below) != 0){
            onGround = true;
            verticalSpeed = -1.0f;
        }
        else
        {
            onGround = false;
        }
        animator.SetBool("OnGround", onGround);
    }

    private void jump()
    {
        verticalSpeed = jumpSpeed;
        animator.SetTrigger("Jump1");
    }
}
