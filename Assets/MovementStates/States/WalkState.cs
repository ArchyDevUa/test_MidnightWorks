using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Walking",true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ExitState(movement,movement.Running);
        }else if (movement.direction.magnitude < 0.1f)
        {
            ExitState(movement,movement.Idle);
        }

        if (movement.verticalInput < 0)
        {
            movement.currentMoveSpeed = movement.walkBackSpeed;
        }
        else
        {
            movement.currentMoveSpeed = movement.walkSpeed;
        }
        
    }

    void ExitState(MovementStateManager movement,MovementBaseState state)
    {
        movement.anim.SetBool("Walking",false);
        movement.SwitchState(state);
    }
}
