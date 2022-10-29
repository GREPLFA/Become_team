using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cctv : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        this.transform.LookAt(Player);
    }
}
