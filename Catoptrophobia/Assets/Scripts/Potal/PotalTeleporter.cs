using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalTeleporter : MonoBehaviour
{
    public Transform player;//�÷��̾�
    public Transform reciever;//�̵��� ��Ż�ݶ��̴�

    private bool playerIsOverlapping = false;//
    void Update()
    {
        if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;//�÷��̾�� ��Ż ���� �Ÿ�
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);//up���Ϳ� �÷��̾�� ��Ż ���� �Ÿ������� ����(|A|*|B|*cos��)
            Debug.Log(dotProduct);
            if (dotProduct <= 0.2f)//=�Ȱ� 90�� �̻��� ��(��>=90�̸� cos�ȴ� ������ �ȴ�)
            {
                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                //rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;
                Debug.Log("12");

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlapping = true;
            Debug.Log("1");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
