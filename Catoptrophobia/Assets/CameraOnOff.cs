using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnOff : MonoBehaviour
{
    public GameObject[] camera;
    public bool isCamera = false;

    void Update()
    {
        CamOnOff();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            isCamera = !isCamera;
        }
    }
    void CamOnOff()
    {
        if(isCamera)
        {
            for(int i = 0; i < camera.Length; i++)
            {
                camera[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < camera.Length; i++)
            {
                camera[i].SetActive(false);
            }
        }
    }
}
