using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrgTag : MonoBehaviour
{
    public bool Trgcheck;

    void Start()
    {
        Trgcheck = false;
    }

    void OnCollisionStay(Collision other)
    {
        Debug.Log("���ۿ� ����");
        if (other.gameObject.name == "Triangle")
        {
            Trgcheck = true;
            Debug.Log("�ﰢ�� ����");
        }
    }
}
