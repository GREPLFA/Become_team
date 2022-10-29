using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayControl : MonoBehaviour
{
    public Image gaugeImage;
    private Vector3 ScreenCenter;


    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    void Update()
    {
        Ray();
   
    }

    void Ray()
    {        
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); //ȭ�� �߾Ӱ� �޾Ƽ� ���� ��
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction*50f, Color.green);

        if (Physics.Raycast(ray, out hit, 50f))
        {
            //Debug.Log(hit.point);
            //Debug.Log(hit.transform.gameObject);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.tag == "Object")
                {
                    GetComponent<Object>().ObjectGet();
                    Destroy(hit.transform.gameObject);
                }
                if (hit.collider.tag == "Door")
                {
                    //��ũ��Ʈ ȣ��
                    Debug.Log("�̰� ���̴�");
                }
            } 
        }
    }
}
