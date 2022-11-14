using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //gameobject
    public CamControl camcontrol;
    //private PlayerControl playercontrol;

    //playermove
    public float speed = 5.0f;
    private Vector3 moveDirection;  //�̵�����
    public float moveX;
    public float moveZ;
    public float mouseX;
    public float mouseY;

    //playercam
    private Transform cameraTransform;

    //rigidbody
    private Rigidbody rigid; 


    public void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //playermove
        moveX=0;
        moveZ=0;
        mouseX=0;
        mouseY=0;

    }
    /*
     * �̺�Ʈ
     * 
     */
    public void Update()
    {

    }

    //�÷��̾� �̵�
    void FixedUpdate()
    {
        MoveControl();
        MouseControl();
        //rigid.Move(moveDirection * speed * Time.deltaTime);
    }

    public void MoveControl()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        //playercontrol.MoveTo(new Vector3(moveX, 0, moveZ)); //moveto�� ���� ���� ����    
    }

    public void MoveTo(Vector3 direction)  //�ܺο��� ������ ���� ������ direction�� ����
    {
        Vector3 movec = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movec.x, 0, movec.z);
        //���ʹϿ� ȸ������ ���������� ���Ͽ� moveDirection�� x z�� ����>ī�޶� ������ �������� �����̰� �� 
    }


    public void MouseControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camcontrol.RotateTo(mouseX, mouseY); //rotateto�� �� ����

    }
}
