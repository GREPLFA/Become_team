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
    private Vector3 moveDirection;  //이동방향
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
     * 이벤트
     * 
     */
    public void Update()
    {

    }

    //플레이어 이동
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

        //playercontrol.MoveTo(new Vector3(moveX, 0, moveZ)); //moveto로 방향 정보 전달    
    }

    public void MoveTo(Vector3 direction)  //외부에서 가져온 방향 정보를 direction에 저장
    {
        Vector3 movec = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movec.x, 0, movec.z);
        //쿼터니온 회전값을 방향정보에 곱하여 moveDirection의 x z에 적용>카메라 전방을 기준으로 움직이게 함 
    }


    public void MouseControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camcontrol.RotateTo(mouseX, mouseY); //rotateto로 값 전달

    }
}
