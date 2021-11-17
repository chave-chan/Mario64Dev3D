using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Camera camera;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    [Header("Jump")]
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpSpeed;
    [Header("Movement")]
    [SerializeField] private KeyCode forwardKey;
    [SerializeField] private KeyCode backKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode runKey;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private float verticalSpeed = 0.0f;
    private bool onGround;

    private void Update()
    {
        Vector3 movement = Vector3.zero;
        
        //Camera control and camera following Mario
        Vector3 l_forward = camera.transform.forward;
        l_forward.y = 0.0f;
        l_forward.Normalize();
        Vector3 l_right = camera.transform.right;
        l_right.y = 0.0f;
        l_right.Normalize();
        if (Input.GetKey(forwardKey)) { movement += l_forward; }
        if (Input.GetKey(backKey)) { movement -= l_forward; }
        if (Input.GetKey(rightKey)) { movement += l_right; }
        if (Input.GetKey(leftKey)) { movement -= l_right; }
        float currentSpeed = Input.GetKey(runKey) ? runSpeed : walkSpeed; //Si es true = run; Si es false = walk
        if(movement.magnitude > 0)
        {
            movement.Normalize();
            
        }
        //Jump
        if (Input.GetKeyDown(jumpKey) && onGround)
        {
            jump();
        }
        //Mario movement
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        movement.y += verticalSpeed * Time.deltaTime;
        CollisionFlags cf = characterController.Move(movement);

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
