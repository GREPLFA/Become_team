using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollEventTest : MonoBehaviour
{

    public float TimeCnt;

    public Transform Doll;


    // Update is called once per frame
    void Update()
    {

        TimeCnt += Time.deltaTime;
        DollCreate();
    }

    void DollCreate()
    {
        GameObject DollSpawn = GameObject.Find("DollSpawn");
        if (TimeCnt > 10)
        {
            Transform prefab_doll = Instantiate(Doll, DollSpawn.transform.position, DollSpawn.transform.rotation);
            Destroy(this, 1f);
            TimeCnt = 0;
        }

    }
}
