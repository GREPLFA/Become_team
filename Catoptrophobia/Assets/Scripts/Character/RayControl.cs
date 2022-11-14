using UnityEngine;
using UnityEngine.UI;


public class RayControl : MonoBehaviour
{
    public Image gaugeImage;

    public AudioClip OpenDoorSource;
    public AudioClip CloseDoorSource;
    AudioSource audiosource;

    private Vector3 ScreenCenter;

    public GameObject arm;

    private bool PaperOnOff;
    public GameObject Paper_1;

    KeyManager keyManager;

    public void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        this.audiosource = GetComponent<AudioSource>();

        PaperOnOff = false;

        keyManager = GameObject.Find("KeyManager").GetComponent<KeyManager>();
    }

    void Update()
    {
        Ray();
    }

    public void Ray()
    {        
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); //ȭ�� �߾Ӱ� �޾Ƽ� ���� ��
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction*5f, Color.green);

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if(hit.collider.CompareTag("Key"))
            {
                hit.collider.gameObject.GetComponent<Outline>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.tag == "Door")
                {
                    Door door_ = hit.transform.gameObject.GetComponent<Door>();
                    Door door_2 = GameObject.Find(door_.name).GetComponent<Door>();
                    Debug.Log("���� �ν�");
                    door_.ChangeDoorState();
                    door_2.ChangeDoorState();
                    Debug.Log("���� ���� ����");

                    if (door_.doorCnt == 2)
                    {
                        DollTest doll = GameObject.Find("EventDoll2").GetComponent<DollTest>();
                        doll.DollDestroy();
                    }

                    Debug.Log(door_.doorCnt);
                    if (door_.doorCnt % 2 != 0)
                    {
                        audiosource.clip = OpenDoorSource;
                    }
                    else if (door_.doorCnt % 2 == 0)
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
                    if (hit.transform.gameObject.name == "GreenCube")//�ش� ������Ʈ�� �̸��� GreenKey��
                    {
                        keyManager.hasGreenKey = true;//hasGreenKey�� true�� �ٲ�
                    }
                    if (hit.transform.gameObject.name == "BlueCube")
                    {
                        keyManager.hasBlueKey = true;
                    }
                    if (hit.transform.gameObject.name == "RedCube")
                    {
                        keyManager.hasRedKey = true;
                    }
                    if (hit.transform.gameObject.name == "RedCube_m")
                    {
                        keyManager.hasRedKey = true;
                    }
                    if (hit.transform.gameObject.name == "BlueCube_m")
                    {
                        keyManager.hasBlueKey = true;
                    }
                    if (hit.transform.gameObject.name == "GreenCube_m")
                    {
                        keyManager.hasGreenKey = true;
                    }
                }
                //KeyHole
                if(hit.transform.gameObject.CompareTag("KeyHole"))
                {
                    if (hit.transform.gameObject.name == "FirstCube")//Ray�� ���� ������Ʈ�� �̸��� FirstCube��
                    {
                        keyManager.targetKeyHole = hit.transform.gameObject;//�ش� ������Ʈ�� keyManager�� targetKeyHole�� ����
                    }
                    if (hit.transform.gameObject.name == "SecondCube")
                    {
                        keyManager.targetKeyHole = hit.transform.gameObject;
                    }
                    if (hit.transform.gameObject.name == "ThirdCube")
                    {
                        keyManager.targetKeyHole = hit.transform.gameObject;
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
}
