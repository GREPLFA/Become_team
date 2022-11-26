using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;//문 열림/닫힘
    public float doorOpenAngle = 90f;//열린 문 각도
    public float doorCloseAngle = 0f;//닫힌 문 각도
    public float smoot = 5f;//문 열리는 속도

    public int doorCnt = 0;

    public void ChangeDoorState()//문 상태 바꾸는 함수
    {
        open = !open;
        doorCnt++;
    }

    void Update()
    {
        DoorMovement();
    }

    public void DoorMovement()//문 여닫는 함수
    {
        if (open)
        {
            if(transform.gameObject.CompareTag("2F_Barrier"))
            {
                Quaternion targetRotation = Quaternion.Euler(0, 0, doorOpenAngle);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
            }    
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smoot * Time.deltaTime);
        }
    }
}
