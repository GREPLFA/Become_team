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
        eulerAngley += mouseX * rotSpeedx;  //마우스 x축 방향 이동 시 오브젝트가 y축 회전
        eulerAnglex -= mouseY * rotSpeedy;  //마우스 y축 방향 이동 시 오브젝트 x축 회전

        eulerAnglex = ClampAngle(eulerAnglex, Minx, Maxx);  //x축 회전 값 각도 제한

        transform.rotation = Quaternion.Euler(eulerAnglex, eulerAngley, 0);  //카메라 회전
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) 
            angle += 360;
        if (angle > 360) 
            angle -= 360;

        return Mathf.Clamp(angle, min, max);  //최대 최소 각도를 설정하여 범위 유지하게 함
    }
}