using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform potal;
    public Transform otherPotal;

    void Update()
    {
        Vector3 playerOffsetFromPotal = playerCamera.position - otherPotal.position;//다른 포탈과 플레이어의 거리
        transform.position = potal.position + playerOffsetFromPotal;//카메라 위치 = 포탈 위치 + 포탈과 플레이어의 거리

        float angularDifferenceBetweenPotalRotations = Quaternion.Angle(potal.rotation, otherPotal.rotation);//두 포탈 간의 각도

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPotalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * new Vector3(0,0,-1);
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
