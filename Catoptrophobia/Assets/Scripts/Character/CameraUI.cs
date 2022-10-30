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
            Debug.Log("클릭함");
            if (OnOff == false)
            {
                CamUi.SetActive(true);
                Debug.Log("캠코더 켬");
                OnOff = true;
                
   
            }
            else if(OnOff==true)
            {
                CamUi.SetActive(false);
                Debug.Log("캠코더 끔");
                OnOff = false;
            }
        }

        if (OnOff == true)
        {
            timer += Time.deltaTime;

            if (timer > CamTime)
            {
                Debug.Log("시간초과");

                CamBattery1.SetActive(false);
                Debug.Log("1번째 비활성화");
            }

            if (timer > CamTime * 2)
            {
                Debug.Log("시간초과");

                CamBattery2.SetActive(false);
                Debug.Log("2번째 비활성화");
            }

            if (timer > CamTime * 3)
            {
                Debug.Log("시간초과");

                CamBattery3.SetActive(false);
                Debug.Log("3번째 비활성화");
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (ROnOff == false)
                {
                    Debug.Log("녹화시작");
                    RECUi.SetActive(true);
                    ROnOff = true;
                }
                else if (ROnOff == true)
                {
                    Debug.Log("녹화 끔");
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
