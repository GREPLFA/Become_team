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
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); //ȭ�� �߾Ӱ� �޾Ƽ� ���� ��
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
                    Debug.Log("���� �ν�");
                    door_.ChangeDoorState();
                    Debug.Log("���� ���� ����");

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
                    Debug.Log("������");
                    hit.transform.parent = arm.gameObject.transform;
                }

                if(PaperOnOff == false)
                {
                    Debug.Log("���� �ν�");
                    if (hit.collider.tag == "Paper")
                    {
                        Debug.Log("���� ����");
                        PaperOnOff = true;
                        Debug.Log("���� ����");
                        Paper_1.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("���� ����");
                    PaperOnOff = false;
                    Debug.Log("���� ����");
                    Paper_1.SetActive(false);
                }
                //Key
                if (hit.transform.gameObject.CompareTag("Key"))//Ray�� ���� ������Ʈ�� �±װ� Key���
                {
                    Destroy(hit.transform.gameObject);//�ش� ������Ʈ �ı�
                    if (hit.transform.gameObject.name == "GreenKey" || hit.transform.gameObject.name == "GreenKey_m")
                    {
                        keyManager.hasGreenKey = true;//hasGreenKey�� true�� �ٲ�
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
                    else if (keyManager.hasBlueKeyClone || keyManager.hasRedKeyClone || keyManager.hasGreenKeyClone || keyManager.hasBlueKey || keyManager.hasRedKey || keyManager.hasGreenKey)//�ƹ� Ű�� ���� ������
                    {
                        keyManager.targetKeyHole = hit.transform.gameObject;//�ش� ������Ʈ�� keyManager�� targetKeyHole�� ����
                    }
                }
            }

            if (hit.transform.gameObject.name == "Frame 1")
            {
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_1 = true;
                GameObject.Find("Light").GetComponent<LightControl>().lightNormal = false;
                Debug.Log("��������");
            }

            if (hit.transform.gameObject.name == "Door_1 (2)")
            {
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_1 = false;
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_2 = true;
                GameObject.Find("Light").GetComponent<LightControl>().lightNormal = false;
                Debug.Log("����");
            }

            if(hit.transform.gameObject.name== "Paper_1")
            {
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_1 = false;
                GameObject.Find("Light").GetComponent<LightControl>().lightEvent_2 = false;
                GameObject.Find("Light").GetComponent<LightControl>().lightNormal = true;
                Debug.Log("����~");
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
