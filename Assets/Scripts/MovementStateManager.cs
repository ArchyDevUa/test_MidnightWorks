using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float groundYOffset;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity = -9.8f;
    private Vector3 direction;
    private float horizontalInput,verticalInput;
    private Vector3 velocity;
    private CharacterController controller;
    private Vector3 spherePosition;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
    }

    void GetDirectionAndMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        direction = transform.forward * verticalInput + transform.right * horizontalInput;
        controller.Move(direction * moveSpeed * Time.deltaTime);

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
