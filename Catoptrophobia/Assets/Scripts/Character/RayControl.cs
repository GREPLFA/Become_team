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
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); //화면 중앙값 받아서 레이 쏨
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
                    Debug.Log("도어 인식");
                    door_.ChangeDoorState();
                    door_2.ChangeDoorState();
                    Debug.Log("도어 상태 변경");

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
                    if (hit.transform.gameObject.name == "GreenCube")//해당 오브젝트의 이름이 GreenKey면
                    {
                        keyManager.hasGreenKey = true;//hasGreenKey를 true로 바꿈
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
                    if (hit.transform.gameObject.name == "FirstCube")//Ray에 맞은 오브젝트의 이름이 FirstCube면
                    {
                        keyManager.targetKeyHole = hit.transform.gameObject;//해당 오브젝트를 keyManager의 targetKeyHole에 저장
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
}
