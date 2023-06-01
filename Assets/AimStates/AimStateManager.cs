using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimStateManager : MonoBehaviour
{
    private AimBaseState currentState;
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();
    
    [SerializeField] private float mouseSence = 1;
    private float xAxis, yAxis;
    [SerializeField] private Transform cameraFollowPlayer;
    [SerializeField] public Animator anim;

    private void Start()
    {
        SwitchState(Hip);
        
    }

    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSence;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSence;
        yAxis = Mathf.Clamp(yAxis, -80, 80);
     
        currentState.UpdateState(this);
    }

    private void LateUpdate()
    {
        cameraFollowPlayer.localEulerAngles = new Vector3(yAxis, cameraFollowPlayer.localEulerAngles.y,cameraFollowPlayer.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
