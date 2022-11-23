using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollEvent : MonoBehaviour
{

    public float lifetime = 1.0f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
