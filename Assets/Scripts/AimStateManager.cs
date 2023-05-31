using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimStateManager : MonoBehaviour
{
    [SerializeField] private float mouseSence = 1;
    private float xAxis, yAxis;
    [SerializeField] private Transform cameraFollowPlayer;

    // Update is called once per frame
    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSence;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSence;
        yAxis = Mathf.Clamp(yAxis, -80, 80);
    }

    private void LateUpdate()
    {
        cameraFollowPlayer.localEulerAngles = new Vector3(yAxis, cameraFollowPlayer.localEulerAngles.y,cameraFollowPlayer.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);

    }
}
