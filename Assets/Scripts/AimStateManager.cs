using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimStateManager : MonoBehaviour
{
    [SerializeField]private Cinemachine.AxisState xAxis, yAxis;
    [SerializeField] private Transform cameraFollowPlayer;

    // Update is called once per frame
    void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }

    private void LateUpdate()
    {
        cameraFollowPlayer.localEulerAngles = new Vector3(yAxis.Value, cameraFollowPlayer.localEulerAngles.y,cameraFollowPlayer.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);

    }
}
