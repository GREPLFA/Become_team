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
        otherHandMirror.position = new Vector3(-handMirror.position.x, handMirror.position.y + 15, handMirror.position.z);

        transform.localEulerAngles = new Vector3(-playerCamera.localEulerAngles.x, player.localEulerAngles.y + 180, playerCamera.localEulerAngles.z);
    }
}
