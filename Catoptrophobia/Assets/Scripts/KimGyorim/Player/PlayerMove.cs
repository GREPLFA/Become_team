using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 출처 : https://truecode.tistory.com/22 / https://makerejoicegames.tistory.com/131 참고

public class PlayerMove : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드.
    public float jumpPower; // 캐릭터 점프 힘.
    float gravity;    // 캐릭터에게 작용하는 중력.

    //private Rigidbody rigid; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    private Vector3 MoveDir;                // 캐릭터의 움직이는 방향.
    private CharacterController controller;
    private CapsuleCollider capsule;
    private Rigidbody rigidbody;
    float mouseX;
    float mouseY;
    float horizontal_MouseSpeed;
    float vertical_MouseSpeed;

    bool isJump = true;

    bool isChar = true;
    void Start()
    {
        speed = 10.0f;
        jumpPower = 6.0f;
        gravity = 20.0f;

        MoveDir = Vector3.zero;
        //rigid = GetComponent<Rigidbody>();

        mouseX = 0.0f;
        mouseY = 0.0f;
        horizontal_MouseSpeed = 3.0f;
        vertical_MouseSpeed = 3.0f;

        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
        //Cursor
        Cursor.lockState = CursorLockMode.Locked;
        capsule = GetComponent<CapsuleCollider>();
        capsule.enabled = false;
    }

    void FixedUpdate()
    {
        playerMove();
    }
    void playerMove()
    {
        characterMove();
        cameraMove();
    }

    void characterMove()
    {
        if(isChar)
        {
            if (controller.isGrounded)
            {
                // 위, 아래 움직임 셋팅. 
                MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다.
                MoveDir = transform.TransformDirection(MoveDir);

                // 스피드 증가.
                MoveDir *= speed;

                // 캐릭터 점프
                if (Input.GetButton("Jump"))
                    MoveDir.y = jumpPower;

            }

            // 캐릭터에 중력 적용.
            MoveDir.y -= gravity * Time.deltaTime;

            controller.Move(MoveDir * Time.deltaTime);
        }
        else
        {
            // 위, 아래 움직임 셋팅. 
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다.
            MoveDir = this.transform.TransformDirection(MoveDir);

            // 스피드 증가.
            MoveDir *= speed;

            // 캐릭터 점프
            if (Input.GetButton("Jump") && isJump)
            {
                rigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
            }

            // 캐릭터 움직임.
            this.transform.position += MoveDir * Time.deltaTime;
        }
    }

    void cameraMove()
    {
        mouseX += Input.GetAxis("Mouse X") * horizontal_MouseSpeed;
        mouseY += Input.GetAxis("Mouse Y") * vertical_MouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f); // 최소값 최대값 지정

        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        isJump = true;
        if (other.gameObject.CompareTag("PotalColider"))
        {
            Debug.Log("1");
            controller.enabled = false;
            capsule.enabled = true;
            isChar = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PotalColider"))
        {
            controller.enabled = true;
            capsule.enabled = false;
            isChar = true;
        }
    }

    /*
    private void PlayJumpSound()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = jumpSound;
        audio.Play();
    }

    private void PlayLandSound()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = landSound;
        audio.Play();
    }
    */


}