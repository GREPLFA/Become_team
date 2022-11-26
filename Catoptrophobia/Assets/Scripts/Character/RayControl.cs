using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RayControl : MonoBehaviour
{
    public bool hasHandMirror;
    public Image gaugeImage;

    public AudioClip OpenDoorSource;
    public AudioClip CloseDoorSource;
    AudioSource audiosource;

    private Vector3 ScreenCenter;

    public GameObject arm;

    private bool PaperOnOff;
    public GameObject Paper_1;

    KeyManager keyManager;
    public GameObject currentKey;

    public float OrgelSpawnTimer;
    public GameObject orgel;
    public GameObject dummyOrgel;
    public void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        this.audiosource = GetComponent<AudioSource>();

        PaperOnOff = false;

        keyManager = GameObject.Find("3FKeyManager").GetComponent<KeyManager>();
    }

    void Update()
    {
        Ray();
        if(hasHandMirror)
        {
            OrgelTimer();
        }
    }

    public void Ray()
    {        
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); //화면 중앙값 받아서 레이 쏨
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction*5f, Color.green);

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.name == "HandMirror_obj")
            {
                hit.collider.gameObject.GetComponent<Outline>().enabled = true;
            }
            if (hit.collider.CompareTag("Key"))
            {
                hit.collider.gameObject.GetComponent<Outline>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(hit.collider.name == "HandMirror_obj")
                {
                    Destroy(hit.transform.gameObject);
                    GameObject.FindGameObjectWithTag("HandMirrorCamera").GetComponent<HandMirror>().enabled = true;
                    hasHandMirror = true;
                }
                if (hit.collider.tag == "Door")
                {
                    Door door_ = hit.transform.gameObject.GetComponent<Door>();
                    Debug.Log("도어 인식");
                    door_.ChangeDoorState();
                    Debug.Log("도어 상태 변경");

                    /*if (door_.doorCnt == 2)
                    {
                        DollTest doll = GameObject.Find("EventDoll2").GetComponent<DollTest>();
                        doll.DollDestroy();
                    }*/
                    if (door_.doorCnt % 4 != 0)
                    {
                        audiosource.clip = OpenDoorSource;
                    }
                    else if (door_.doorCnt % 4 == 0)
                    {
                        audiosource.clip = CloseDoorSource;
                    }

                    audiosource.Play();

                }

                if (hit.collider.tag == "Puzzle")
                {
                    Debug.Log("집었음");
                    hit.transform.parent = arm.gameObject.transform;
                }

                if(PaperOnOff == false)
                {
                    Debug.Log("종이 인식");
                    if (hit.collider.tag == "Paper")
                    {
                        Debug.Log("상태 변경");
                        PaperOnOff = true;
                        Debug.Log("종이 띄우기");
                        Paper_1.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("상태 변경");
                    PaperOnOff = false;
                    Debug.Log("종이 끄기");
                    Paper_1.SetActive(false);
                }
                //Key
                if (hit.transform.gameObject.CompareTag("Key"))//Ray에 맞은 오브젝트의 태그가 Key라면
                {
                    Destroy(hit.transform.gameObject);//해당 오브젝트 파괴
                    if (hit.transform.gameObject.name == "GreenKey" || hit.transform.gameObject.name == "GreenKey_m")
                    {
                        keyManager.hasGreenKey = true;//hasGreenKey를 true로 바꿈
                    }
                    if (hit.transform.gameObject.name == "BlueKey" || hit.transform.gameObject.name == "BlueKey_m")
                    {
                        keyManager.hasBlueKey = true;
                    }
                    if (hit.transform.gameObject.name == "RedKey" || hit.transform.gameObject.name == "RedKey_m")
                    {
                        keyManager.hasRedKey = true;
                    }
                }
                //KeyHole
                if(hit.transform.gameObject.CompareTag("KeyHole"))
                {
                    if (hit.transform.childCount == 1 && (keyManager.hasBlueKey || keyManager.hasRedKey || keyManager.hasGreenKey))
                    {
                        keyManager.targetKeyHole = hit.transform.gameObject;
                        if (hit.transform.GetChild(0).gameObject.name == "RedKey(Clone)")
                        {
                            Destroy(hit.transform.GetChild(0).gameObject);
                            keyManager.hasRedKeyClone = true;
                        }
                        else if (hit.transform.GetChild(0).gameObject.name == "GreenKey(Clone)")
                        {
                            Destroy(hit.transform.GetChild(0).gameObject);
                            keyManager.hasGreenKeyClone = true;
                        }
                        else if (hit.transform.GetChild(0).gameObject.name == "BlueKey(Clone)")
                        {
                            Destroy(hit.transform.GetChild(0).gameObject);
                            keyManager.hasBlueKeyClone = true;
                        }
                    }
                    else if(hit.transform.childCount == 1 && (!keyManager.hasBlueKeyClone || !keyManager.hasRedKeyClone || !keyManager.hasGreenKeyClone || !keyManager.hasBlueKey || !keyManager.hasRedKey || !keyManager.hasGreenKey))
                    {
                        Destroy(hit.transform.GetChild(0).gameObject);
                        if(hit.transform.GetChild(0).gameObject.name == "RedKey(Clone)")
                        {
                            keyManager.hasRedKey = true;
                        }
                        else if(hit.transform.GetChild(0).gameObject.name == "BlueKey(Clone)")
                        {
                            keyManager.hasBlueKey = true;
                        }
                        else if (hit.transform.GetChild(0).gameObject.name == "GreenKey(Clone)")
                        {
                            keyManager.hasGreenKey = true;
                        }
                    }
                    else if (keyManager.hasBlueKeyClone || keyManager.hasRedKeyClone || keyManager.hasGreenKeyClone || keyManager.hasBlueKey || keyManager.hasRedKey || keyManager.hasGreenKey)//아무 키나 갖고 있으면
                    {
                        keyManager.targetKeyHole = hit.transform.gameObject;//해당 오브젝트를 keyManager의 targetKeyHole에 저장
                    }
                }
            }

            if (hit.transform.gameObject.name == "Frame 1")
            {
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_1 = true;
                GameObject.Find("Light").GetComponent<LightControl>().lightNormal = false;
                Debug.Log("깜빡깜빡");
            }

            if (hit.transform.gameObject.name == "Door_1 (2)")
            {
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_1 = false;
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_2 = true;
                GameObject.Find("Light").GetComponent<LightControl>().lightNormal = false;
                Debug.Log("정전");
            }

            if(hit.transform.gameObject.name== "Paper_1")
            {
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_1 = false;
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_2 = false;
                GameObject.Find("Light").GetComponent<LightControl>().lightNormal = true;
                Debug.Log("멀쩡~");
            }
        }
    }
    void OrgelTimer()
    {
        if (OrgelSpawnTimer > 0)
        {
            OrgelSpawnTimer -= Time.deltaTime;
        }
        else if (OrgelSpawnTimer < 0)
        {
            orgel.SetActive(true);
            dummyOrgel.SetActive(true);
            OrgelSpawnTimer = 0;
            hasHandMirror = false;
        }
    }
}
