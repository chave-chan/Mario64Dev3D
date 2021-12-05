using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerController : MonoBehaviour, IRestartGame
{
    [Header("Components")] [SerializeField]
    private Camera camera;

    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameManager gameManager;
    [Header("Jump")] [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpSpeed;
    [Header("Movement")] [SerializeField] private KeyCode forwardKey;
    [SerializeField] private KeyCode backKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode runKey;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private Transform hitPosition;
    private bool gotHitted = false;
    private float verticalSpeed = 0.0f;
    private bool onGround;
    public int jumps = 0;
    public float timeBtwJump = 5f;

    private Rigidbody rb;

    private void Update()
    {
        Vector3 movement = Vector3.zero;
        //Mario moving based on Camera position
        Vector3 l_forward = camera.transform.forward;
        l_forward.y = 0.0f;
        l_forward.Normalize();
        Vector3 l_right = camera.transform.right;
        l_right.y = 0.0f;
        l_right.Normalize();
        
        if (Input.GetKey(forwardKey))
        {
            movement += l_forward;
            jumps = 0;
        }

        if (Input.GetKey(backKey))
        {
            movement -= l_forward;
            jumps = 0;
        }

        if (Input.GetKey(rightKey))
        {
            movement += l_right;
            jumps = 0;
        }

        if (Input.GetKey(leftKey))
        {
            movement -= l_right;
            jumps = 0;
        }

        float currentSpeed = Input.GetKey(runKey) ? runSpeed : walkSpeed; //Si es true = run; Si es false = walk
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            transform.forward = movement;
            movement *= currentSpeed * Time.deltaTime;
        }

        //Idle, Walk & Run Animations
        float animSpeed = movement.x == 0 ? 0.0f : 0.3f;
        if (Input.GetKey(runKey))
        {
            animSpeed = 0.8f;
        }

        animator.SetFloat("Speed", animSpeed);

        //Jump
        if (Input.GetKeyDown(jumpKey) && onGround)
        {
            if (jumps == 1 && timeBtwJump >= 0f)
            {
                DoubleJump();
            }
            else if (jumps == 2 && timeBtwJump >= 0f)
            {
                TripleJump();
            }
            else
            {
                Jump();
            }
        }

        if (onGround)
            timeBtwJump -= Time.deltaTime;
        if (timeBtwJump <= 0f)
            jumps = 0;
        if (!onGround)
            timeBtwJump = 5f;

        //Mario movement
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        movement.y += verticalSpeed * Time.deltaTime;
        CollisionFlags cf = characterController.Move(movement);

        if ((cf & CollisionFlags.Below) != 0)
        {
            onGround = true;
            verticalSpeed = -1.0f;
        }
        else
        {
            if ((cf & CollisionFlags.Above) != 0 && verticalSpeed > 0)
            {
                verticalSpeed = 0;
            }

            onGround = false;
        }

        animator.SetBool("OnGround", onGround);
    }

    private void Jump()
    {
        verticalSpeed = jumpSpeed;
        animator.SetTrigger("Jump1");
        jumps = 1;
    }

    private void DoubleJump()
    {
        verticalSpeed = jumpSpeed + (jumpSpeed * 0.25f);
        animator.SetTrigger("Jump2");
        jumps = 2;
    }

    private void TripleJump()
    {
        verticalSpeed = jumpSpeed + (jumpSpeed * 0.5f);
        animator.SetTrigger("Jump3");
        jumps = 0;
    }

    private CheckPoint currentCheckPoint;

    public void setCheckPoint(CheckPoint checkPoint)
    {
        if (currentCheckPoint == null || currentCheckPoint.getIndex() < checkPoint.getIndex())
        {
            currentCheckPoint = checkPoint;
        }
    }

    private void Start()
    {
        gameManager.AddRestartListener(this);
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        gameManager.RemoveRestartListener(this);
    }

    private bool resetPos = false;

    public void RestartGame()
    {
        resetPos = true;
    }

    private void LateUpdate()
    {
        if (gotHitted)
        {
            //TODO: ANIMATOR ANIMATION OF GETTING HIT
            gotHitted = false;
        }
        
        if (resetPos)
        {
            Transform t = currentCheckPoint.getCheckPointTransform();
            transform.position = t.position;
            transform.rotation = t.rotation;
            resetPos = false;
        }
    }

    public void getHit()
    {
        gotHitted = true;
    }
}