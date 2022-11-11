using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 출처 : https://truecode.tistory.com/22 / https://makerejoicegames.tistory.com/131 참고

public class PlayerMove : MonoBehaviour
{
    float speed;      // 캐릭터 움직임 스피드.
    float jumpSpeed; // 캐릭터 점프 힘.
    float gravity;    // 캐릭터에게 작용하는 중력.

    private Rigidbody playerRigidbody; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    private Vector3 MoveDir;                // 캐릭터의 움직이는 방향.

    float mouseX;
    float mouseY;
    float horizontal_MouseSpeed;
    float vertical_MouseSpeed;

    public AudioClip jumpSound;
    public AudioClip landSound;

    Vector3 playerDir;

    void Start()
    {
        speed = 4.0f;
        jumpSpeed = 6.0f;
        gravity = 20.0f;

        MoveDir = Vector3.zero;
        playerRigidbody = GetComponent<Rigidbody>();

        mouseX = 0.0f;
        mouseY = 0.0f;
        horizontal_MouseSpeed = 5.0f;
        vertical_MouseSpeed = 6.0f;

        //Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
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
        // 위, 아래 움직임 셋팅. 
        MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다.
        MoveDir = this.transform.TransformDirection(MoveDir);
/*
        // 스피드 증가.
        MoveDir *= speed;*/

        /*// 캐릭터 점프
        if (Input.GetButton("Jump"))
        {
            MoveDir.y = jumpSpeed;
            PlayJumpSound();
        }*/

        // 캐릭터에 중력 적용.
        MoveDir.y -= gravity * Time.deltaTime;

        // 캐릭터 움직임.
        playerRigidbody.velocity = MoveDir * speed;
    }

    void cameraMove()
    {
        mouseX += Input.GetAxis("Mouse X") * horizontal_MouseSpeed;
        mouseY += Input.GetAxis("Mouse Y") * vertical_MouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f); // 최소값 최대값 지정

        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }

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

    /*void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.name == "wooden floor (1)")
        {
            GameObject.Find("Light").GetComponent<LightControl>().lightEvent_1 = true;
        }

        if (other.gameObject.name == "Cube (1)")
        {
            GameObject.Find("Light").GetComponent<LightControl>().lightEvent_1 = false;
            GameObject.Find("Light").GetComponent<LightControl>().lightEvent_2 = true;
        }
    }*/
}
