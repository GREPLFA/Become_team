using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    private float rotSpeedx = 5;
    private float rotSpeedy = 5;
    private float Minx = -60;
    private float Maxx = 60;
    private float eulerAnglex;
    private float eulerAngley;

    public void RotateTo(float mouseX, float mouseY)
    {
        eulerAngley += mouseX * rotSpeedx;  //���콺 x�� ���� �̵� �� ������Ʈ�� y�� ȸ��
        eulerAnglex -= mouseY * rotSpeedy;  //���콺 y�� ���� �̵� �� ������Ʈ x�� ȸ��

        eulerAnglex = ClampAngle(eulerAnglex, Minx, Maxx);  //x�� ȸ�� �� ���� ����

        transform.rotation = Quaternion.Euler(eulerAnglex, eulerAngley, 0);  //ī�޶� ȸ��
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) 
            angle += 360;
        if (angle > 360) 
            angle -= 360;

        return Mathf.Clamp(angle, min, max);  //�ִ� �ּ� ������ �����Ͽ� ���� �����ϰ� ��
    }
}