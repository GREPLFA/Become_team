using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;//�� ����/����
    public float doorOpenAngle = 90f;//���� �� ����
    public float doorCloseAngle = 0f;//���� �� ����
    public float smoot = 5f;//�� ������ �ӵ�

    public int doorCnt = 0;

    public void ChangeDoorState()//�� ���� �ٲٴ� �Լ�
    {
        open = !open;
        doorCnt++;
    }

    void Update()
    {
        DoorMovement();
    }

    public void DoorMovement()//�� ���ݴ� �Լ�
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
