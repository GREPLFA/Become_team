using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;//�� ����/����
    public float doorOpenAngle = 90f;//���� �� ����
    public float doorCloseAngle = 0f;//���� �� ����
    public float smoot = 2f;//�� ������ �ӵ�

    public void ChangeDoorState()//�� ���� �ٲٴ� �Լ�
    {
        open = !open;
    }
    void Update()
    {
        DoorMovement();
    }
    void DoorMovement()//�� ���ݴ� �Լ�
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smoot * Time.deltaTime);
        }
    }
}
