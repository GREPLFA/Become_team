using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalTeleporter : MonoBehaviour
{
    public Transform player;//플레이어
    public Transform reciever;//이동할 포탈콜라이더

    private bool playerIsOverlapping = false;//
    void Update()
    {
        if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;//플레이어와 포탈 간의 거리
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);//up벡터와 플레이어와 포탈 간의 거리벡터의 내적(|A|*|B|*cosΘ)
            Debug.Log(dotProduct);
            if (dotProduct <= 0.2f)//=Θ가 90도 이상일 때(Θ>=90이면 cosΘ는 음수가 된다)
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
