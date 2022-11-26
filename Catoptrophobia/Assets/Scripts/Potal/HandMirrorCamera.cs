using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMirrorCamera : MonoBehaviour
{
    public Transform player;
    public Transform playerCamera;
    public Transform handMirror;
    public Transform otherHandMirror;

    void Update()
    {
        otherHandMirror.position = new Vector3(handMirror.position.x, handMirror.position.y, -handMirror.position.z);

        transform.localEulerAngles = new Vector3(-player.localEulerAngles.x, player.localEulerAngles.y, playerCamera.localEulerAngles.z);
    }
}
