using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private CamControl camcontrol;
    private PlayerControl playercontrol;

    public float speed = 5.0f;

    private Vector3 moveDirection;  //이동방향

    [SerializeField]
    private Transform cameraTransform;
    private CharacterController cc;

    public float moveX;
    public float moveZ;
    public float mouseX;
    public float mouseY;

    //public float stamina = 1000;
    //private float maxStamina;
    //private float minStamina;

    //public RectTransform stBar;

    public void Start()
    {
        playercontrol = GetComponent<PlayerControl>();
        
        cc = GetComponent<CharacterController>();

        moveX=0;
        moveZ=0;
        mouseX=0;
        mouseY=0;

        //maxStamina = stamina;
        //minStamina = 0;
        //stBar.localScale = Vector3.one;
    }

    public void Update()
    {
        MoveControl();
        MouseControl();
        //Sprint();
        //STBar();

        cc.Move(moveDirection * speed * Time.deltaTime);
    }

    public void MoveControl()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        playercontrol.MoveTo(new Vector3(moveX, 0, moveZ)); //moveto로 방향 정보 전달    
    }

    public void MoveTo(Vector3 direction)  //외부에서 가져온 방향 정보를 direction에 저장
    {
        Vector3 movec = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movec.x, 0, movec.z);
        //쿼터니온 회전값을 방향정보에 곱하여 moveDirection의 x z에 적용>카메라 전방을 기준으로 움직이게 함 
    }

    //public void Sprint()
    //{
    //   if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        if (stamina > minStamina)
    //        {
    //            speed = 7.5f;
    //        }
    //        else
    //            speed = 5.0f;
    //    }
    //    else
    //        speed = 5.0f;
    //}

    public void MouseControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camcontrol.RotateTo(mouseX, mouseY); //rotateto로 값 전달

    }

    //public void STBar()
    //{
    //    if(cc.velocity.sqrMagnitude>=7.5&&Input.GetKey(KeyCode.LeftShift) && stamina > minStamina){
    //        stamina-=1;
    //        stBar.localScale = new Vector3(stamina/maxStamina, 1, 1);
    //    }
    //    else if (stamina < maxStamina)
    //    {
    //        stamina+=0.5f;
    //        stBar.localScale = new Vector3(stamina/maxStamina, 1, 1);
    //    }
    //}
}
