using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private PlayerControl playercontrol;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playercontrol = GameObject.Find("PlayObject").GetComponent<PlayerControl>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim();
    }

    public void Anim()
    {

        if (playercontrol.moveX != 0 || playercontrol.moveZ != 0)
        {
            anim.SetBool("isWalk", true);

            if (Input.GetKey(KeyCode.LeftShift) && playercontrol.speed == 7.5)
            {
                anim.SetBool("isRun", true);
            }
            else
                anim.SetBool("isRun", false);
        }
        else
            anim.SetBool("isWalk", false);

        if (playercontrol.mouseX != 0 || playercontrol.mouseY != 0) //제자리 회전 시에도 애니 적용
        {
            anim.SetBool("isWalk", true);
        }
    }
}
