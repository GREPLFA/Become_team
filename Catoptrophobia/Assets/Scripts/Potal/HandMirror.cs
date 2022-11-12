using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMirror : MonoBehaviour
{
    RaycastHit hit;
    float maxDistance = 4f;
    public bool isHit = false;
    public bool hasKey = false;
    public bool mirrorOn = false;

    public GameObject handMirror;
    public float timer = 0f;

    void Update()
    {
        HandMirrorRay();
        MirrorOnOff();
    }
    void HandMirrorRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.blue);
            if (hit.transform.gameObject.CompareTag("Object"))
            {
                hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                if (isHit)
                {
                    hit.transform.gameObject.SetActive(false);
                    isHit = false;
                    hasKey = true;
                }
            }
            if (hit.transform.gameObject.CompareTag("Orgel"))
            {
                hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                if (isHit)
                {
                    GameObject[] orgel = GameObject.FindGameObjectsWithTag("Orgel");
                    for (int i = 0; i < orgel.Length; i++)
                    {
                        orgel[i].transform.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    void MirrorOnOff()
    {
        if(!mirrorOn)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                handMirror.SetActive(true);
                mirrorOn = true;
            }
        }
        else if(mirrorOn)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                handMirror.SetActive(false);
                mirrorOn = false;
            }
        }
    }
}
