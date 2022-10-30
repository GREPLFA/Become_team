using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{
    private bool OnOff;
    public GameObject CamUi;

    private bool ROnOff;
    public GameObject RECUi;

    public GameObject CamBattery1;
    public GameObject CamBattery2;
    public GameObject CamBattery3;

    float timer;
    float CamTime;

    void Start()
    {
        OnOff = false;
        ROnOff = false;

        timer = 0.0f;
        CamTime = 2.0f;
    }

    void Update()
    {
        UI();
    }

    void UI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Ŭ����");
            if (OnOff == false)
            {
                CamUi.SetActive(true);
                Debug.Log("ķ�ڴ� ��");
                OnOff = true;
                
   
            }
            else if(OnOff==true)
            {
                CamUi.SetActive(false);
                Debug.Log("ķ�ڴ� ��");
                OnOff = false;
            }
        }

        if (OnOff == true)
        {
            timer += Time.deltaTime;

            if (timer > CamTime)
            {
                Debug.Log("�ð��ʰ�");

                CamBattery1.SetActive(false);
                Debug.Log("1��° ��Ȱ��ȭ");
            }

            if (timer > CamTime * 2)
            {
                Debug.Log("�ð��ʰ�");

                CamBattery2.SetActive(false);
                Debug.Log("2��° ��Ȱ��ȭ");
            }

            if (timer > CamTime * 3)
            {
                Debug.Log("�ð��ʰ�");

                CamBattery3.SetActive(false);
                Debug.Log("3��° ��Ȱ��ȭ");
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (ROnOff == false)
                {
                    Debug.Log("��ȭ����");
                    RECUi.SetActive(true);
                    ROnOff = true;
                }
                else if (ROnOff == true)
                {
                    Debug.Log("��ȭ ��");
                    RECUi.SetActive(false);
                    ROnOff = false;
                }


            }

        }
        else if (OnOff == false)
        {
            ROnOff = false;
        }
    }
}
