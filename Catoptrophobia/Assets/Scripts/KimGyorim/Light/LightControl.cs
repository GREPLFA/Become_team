using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject[] singlLight;

    public bool lightEvent_1 = false;
    public bool lightEvent_2 = false;

    void Update()
    {
        LightPower();
    }

    void LightPower()
    {
        if (lightEvent_1)
            singlLight[Random.Range(0, 7)].GetComponent<Light>().intensity = Random.Range(0, 8);
        if (lightEvent_2)
            for (int i = 0; i < singlLight.Length; i++)
                singlLight[i].GetComponent<Light>().intensity = 0;
    }
}
