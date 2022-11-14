using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject greenKey;
    public GameObject blueKey;
    public GameObject redKey;
    public bool hasRedKey = false;
    public bool hasBlueKey = false;
    public bool hasGreenKey = false;
    public bool firstKeyUnlock = false;
    public bool secondKeyUnlock = false;
    public bool thirdKeyUnlock = false;
    public int[] key = new int[3];
    public int[] key_mirror = new int[3];
    public GameObject[] keyPosition = new GameObject[3];
    public GameObject[] keyPosition_mirror = new GameObject[3];
    public GameObject targetKeyHole;
    void Start()
    {
        
    }

    void Update()
    {
        
        keyHole();
        ChangeKey();
    }
    void keyHole()
    {
        
    }
    void ChangeKey()//KeyHole�� ť�� �ִ� �Լ�
    {
        if(hasGreenKey && targetKeyHole != null)//�ʷ�Ű�� ���� ������(���� ���� ���� targetKeyHole != null)
        {
            Instantiate(greenKey, targetKeyHole.transform);//�ʷ�ť�� �������� Ray�� ���� KeyHole�� ����
            if(GameObject.Find("Key").transform.Find("BlueCube"))//BlueCube ������Ʈ�� ���̾��Ű�� ������
            {
                GameObject.Find("Key").transform.Find("BlueCube").gameObject.SetActive(true);//BlueCube Ȱ��ȭ
            }
            hasGreenKey = false;//�ʷ�Ű ���
            targetKeyHole = null;//Ÿ�� KeyHole �����
        }
        if (hasBlueKey && targetKeyHole != null)
        {
            Instantiate(blueKey, targetKeyHole.transform);
            if(GameObject.Find("Key").transform.Find("RedCube"))
            {
                GameObject.Find("Key").transform.Find("RedCube").gameObject.SetActive(true);
            }
            else
            {
                GameObject.Find("Key").transform.Find("GreenCube_m").gameObject.SetActive(true);
            }
            hasBlueKey = false;
            targetKeyHole = null;
        }
        if (hasRedKey && targetKeyHole != null)
        {
            Instantiate(redKey, targetKeyHole.transform);
            if(GameObject.Find("Key").transform.Find("RedCube_m"))
            {
                GameObject.Find("Key").transform.Find("RedCube_m").gameObject.SetActive(true);
            }
            else
            {
                GameObject.Find("Key").transform.Find("BlueCube_m").gameObject.SetActive(true);
            }
            hasRedKey = false;
            targetKeyHole = null;
        }

    }
}
