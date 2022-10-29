using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalTeleport : MonoBehaviour
{
    public PotalController potalController;
    private void OnTriggerEnter(Collider other)
    {
        potalController.Teleport();
    }
}
