using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    RayControl rayControl;
    public GameObject greenKey;
    public GameObject blueKey;
    public GameObject redKey;
    public bool hasRedKey = false;
    public bool hasBlueKey = false;
    public bool hasGreenKey = false;
    public bool hasRedKeyClone = false;
    public bool hasBlueKeyClone = false;
    public bool hasGreenKeyClone = false;
    public bool hasAllKey = false;
    public bool firstKeyUnlock = false;
    public bool secondKeyUnlock = false;
    public bool thirdKeyUnlock = false;
    public GameObject[] keyPosition = new GameObject[3];
    public GameObject[] keyPosition_mirror = new GameObject[3];
    public GameObject targetKeyHole;

    public GameObject door1;
    public GameObject door2;
    void Start()
    {
        rayControl = GameObject.Find("KeyManager").transform.gameObject.GetComponent<RayControl>();
    }

    void Update()
    {
        if(hasAllKey)
        {
            OpenDoor();
        }
        ChangeKey();
    }
    void ChangeKey()//KeyHole�� ť�� �ִ� �Լ�
    {
        if (hasGreenKey && targetKeyHole != null)//�ʷ�Ű�� ���� ������(���� ���� ���� targetKeyHole != null)
        {
            Instantiate(greenKey, targetKeyHole.transform);//�ʷ�ť�� �������� Ray�� ���� KeyHole�� ����
            if (GameObject.Find("Key").transform.Find("BlueKey"))//BlueCube ������Ʈ�� ���̾��Ű�� ������
            {
                GameObject.Find("Key").transform.Find("BlueKey").gameObject.SetActive(true);//BlueCube Ȱ��ȭ
            }
            if(GameObject.Find("Key").transform.childCount == 0)
            {
                hasAllKey = true;
            }
            hasGreenKey = false;//�ʷ�Ű ���
            targetKeyHole = null;//Ÿ�� KeyHole �����
        }
        if (hasBlueKey && targetKeyHole != null)
        {
            Instantiate(blueKey, targetKeyHole.transform);
            if (GameObject.Find("Key").transform.Find("RedKey"))
            {
                GameObject.Find("Key").transform.Find("RedKey").gameObject.SetActive(true);
            }
            else
            {
                GameObject.Find("Key").transform.Find("GreenKey_m").gameObject.SetActive(true);
            }
            hasBlueKey = false;
            targetKeyHole = null;
        }
        if (hasRedKey && targetKeyHole != null)
        {
            Instantiate(redKey, targetKeyHole.transform);
            if (GameObject.Find("Key").transform.Find("RedKey_m"))
            {
                GameObject.Find("Key").transform.Find("RedKey_m").gameObject.SetActive(true);
            }
            else
            {
                GameObject.Find("Key").transform.Find("BlueKey_m").gameObject.SetActive(true);
            }
            hasRedKey = false;
            targetKeyHole = null;
        }
        if (hasGreenKeyClone && targetKeyHole != null)
        {
            Instantiate(greenKey, targetKeyHole.transform);
            hasGreenKeyClone = false;
            targetKeyHole = null;
        }
        if (hasBlueKeyClone && targetKeyHole != null)
        {
            Instantiate(blueKey, targetKeyHole.transform);
            hasBlueKeyClone = false;
            targetKeyHole = null;
        }
        if (hasRedKeyClone && targetKeyHole != null)
        {
            Instantiate(redKey, targetKeyHole.transform);
            hasRedKeyClone = false;
            targetKeyHole = null;
        }
    }
    void OpenDoor()
    {
        if (firstKeyUnlock && secondKeyUnlock && thirdKeyUnlock)
        {
            door1.GetComponent<Door>().open = true;
            door2.GetComponent<Door>().open = true;
            transform.GetComponent<AudioSource>().enabled = true;
        }
        if (keyPosition[0].transform.GetChild(0).name == keyPosition_mirror[2].transform.GetChild(0).name)
        {
            firstKeyUnlock = true;
        }
        if (keyPosition[1].transform.GetChild(0).name == keyPosition_mirror[1].transform.GetChild(0).name)
        {
            secondKeyUnlock = true;
        }
        if (keyPosition[2].transform.GetChild(0).name == keyPosition_mirror[0].transform.GetChild(0).name)
        {
            thirdKeyUnlock = true;
        }
    }
}
