using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ó : https://truecode.tistory.com/22 / https://makerejoicegames.tistory.com/131 ����

public class PlayerMove : MonoBehaviour
{
    public float speed;      // ĳ���� ������ ���ǵ�.
    public float jumpPower; // ĳ���� ���� ��.
    float gravity;    // ĳ���Ϳ��� �ۿ��ϴ� �߷�.

    //private Rigidbody rigid; // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.
    private Vector3 MoveDir;                // ĳ������ �����̴� ����.
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
                // ��, �Ʒ� ������ ����. 
                MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                // ���͸� ���� ��ǥ�� ���ؿ��� ���� ��ǥ�� �������� ��ȯ�Ѵ�.
                MoveDir = transform.TransformDirection(MoveDir);

                // ���ǵ� ����.
                MoveDir *= speed;

                // ĳ���� ����
                if (Input.GetButton("Jump"))
                    MoveDir.y = jumpPower;

            }

            // ĳ���Ϳ� �߷� ����.
            MoveDir.y -= gravity * Time.deltaTime;

            controller.Move(MoveDir * Time.deltaTime);
        }
        else
        {
            // ��, �Ʒ� ������ ����. 
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // ���͸� ���� ��ǥ�� ���ؿ��� ���� ��ǥ�� �������� ��ȯ�Ѵ�.
            MoveDir = this.transform.TransformDirection(MoveDir);

            // ���ǵ� ����.
            MoveDir *= speed;

            // ĳ���� ����
            if (Input.GetButton("Jump") && isJump)
            {
                rigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
            }

            // ĳ���� ������.
            this.transform.position += MoveDir * Time.deltaTime;
        }
    }

    void cameraMove()
    {
        mouseX += Input.GetAxis("Mouse X") * horizontal_MouseSpeed;
        mouseY += Input.GetAxis("Mouse Y") * vertical_MouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f); // �ּҰ� �ִ밪 ����

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