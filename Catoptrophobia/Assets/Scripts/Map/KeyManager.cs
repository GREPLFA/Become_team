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
    void ChangeKey()//KeyHole에 큐브 넣는 함수
    {
        if(hasGreenKey && targetKeyHole != null)//초록키를 갖고 있으면(오류 막기 위해 targetKeyHole != null)
        {
            Instantiate(greenKey, targetKeyHole.transform);//초록큐브 프리펩을 Ray에 맞은 KeyHole에 생성
            if(GameObject.Find("Key").transform.Find("BlueCube"))//BlueCube 오브젝트가 하이어라키에 있으면
            {
                GameObject.Find("Key").transform.Find("BlueCube").gameObject.SetActive(true);//BlueCube 활성화
            }
            hasGreenKey = false;//초록키 사용
            targetKeyHole = null;//타겟 KeyHole 비워줌
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
