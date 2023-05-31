using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float groundYOffset;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity = -9.8f;
    public Vector3 direction;
    public float horizontalInput,verticalInput;
    private Vector3 velocity;
    private CharacterController controller;
    private Vector3 spherePosition;
    
    
    private MovementBaseState currentState;
    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public RunningState Running = new RunningState();

    [SerializeField]public float currentMoveSpeed;
    public float walkSpeed =3, walkBackSpeed =2;
    public float runSpeed = 7 , runBackSpeed = 5;

    [HideInInspector] public Animator anim;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        SwitchState(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
        anim.SetFloat("hzInput",horizontalInput);
        anim.SetFloat("vInput",verticalInput);
        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        direction = transform.forward * verticalInput + transform.right * horizontalInput;
        controller.Move(direction.normalized * moveSpeed * Time.deltaTime);

    }

    bool IsGrounded()
    {
        spherePosition = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePosition, controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }   
    }

    void Gravity()
    {
        if (!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
