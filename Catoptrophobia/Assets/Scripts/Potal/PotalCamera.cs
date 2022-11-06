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
        Vector3 playerOffsetFromPotal = playerCamera.position - otherPotal.position;//�ٸ� ��Ż�� �÷��̾��� �Ÿ�
        transform.position = potal.position + playerOffsetFromPotal;//ī�޶� ��ġ = ��Ż ��ġ + ��Ż�� �÷��̾��� �Ÿ�

        float angularDifferenceBetweenPotalRotations = Quaternion.Angle(potal.rotation, otherPotal.rotation);//�� ��Ż ���� ����

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPotalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * new Vector3(0,0,-1);
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
