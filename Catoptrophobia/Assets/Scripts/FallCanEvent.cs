using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCanEvent : MonoBehaviour
{
    public bool isFall;
    public GameObject can;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            
        }
    }
}
