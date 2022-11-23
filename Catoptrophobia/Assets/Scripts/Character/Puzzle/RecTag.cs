using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecTag : MonoBehaviour
{
    public bool Reccheck;

    void Start()
    {
        Reccheck = false;
    }

    void OnCollisionStay(Collision other)
    {
        Debug.Log("±¸¸Û¿¡ ³ÖÀ½");
        if (other.gameObject.name == "Cube")
        {
            Reccheck = true;
            Debug.Log("»ç°¢Çü ³¢¿ò");
        }
    }
}
