using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (movement.direction.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement.SwitchState(movement.Running);
            }
            else
            {
                movement.SwitchState(movement.Walk);
            }
        }
    }
}
