using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalController : MonoBehaviour
{
    public Transform land1, land2;
    public Transform playerRoot, playerCam;
    public Transform potalCam;

    public RenderTexture renderTexture;
    void Start()
    {
        renderTexture.width = Screen.width;
        renderTexture.height = Screen.height;
    }
    void Update()
    {
        Vector3 playerOffset = playerCam.position - land1.position;

        potalCam.position = land2.position + playerOffset;
        potalCam.rotation = playerCam.rotation;
    }

    public void Teleport()
    {
        var playerLand = land1;
        land1 = land2;
        land2 = playerLand;

        playerRoot.position = potalCam.position;
    }
}
