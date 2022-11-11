using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ó : https://truecode.tistory.com/22 / https://makerejoicegames.tistory.com/131 ����

public class PlayerMove : MonoBehaviour
{
    float speed;      // ĳ���� ������ ���ǵ�.
    float jumpSpeed; // ĳ���� ���� ��.
    float gravity;    // ĳ���Ϳ��� �ۿ��ϴ� �߷�.

    private Rigidbody playerRigidbody; // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.
    private Vector3 MoveDir;                // ĳ������ �����̴� ����.

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
        // ��, �Ʒ� ������ ����. 
        MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        // ���͸� ���� ��ǥ�� ���ؿ��� ���� ��ǥ�� �������� ��ȯ�Ѵ�.
        MoveDir = this.transform.TransformDirection(MoveDir);
/*
        // ���ǵ� ����.
        MoveDir *= speed;*/

        /*// ĳ���� ����
        if (Input.GetButton("Jump"))
        {
            MoveDir.y = jumpSpeed;
            PlayJumpSound();
        }*/

        // ĳ���Ϳ� �߷� ����.
        MoveDir.y -= gravity * Time.deltaTime;

        // ĳ���� ������.
        playerRigidbody.velocity = MoveDir * speed;
    }

    void cameraMove()
    {
        mouseX += Input.GetAxis("Mouse X") * horizontal_MouseSpeed;
        mouseY += Input.GetAxis("Mouse Y") * vertical_MouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f); // �ּҰ� �ִ밪 ����

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
