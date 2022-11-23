using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{

    public GameObject Obj;
    public GameObject line;

    public GameObject MoveObj;

    public bool DstCheck;

    private int MoveObjDist;
    private int ObjDist;

    // Start is called before the first frame update
    void Start()
    {
        DstCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        ObjDist = (int)Vector3.Distance(Obj.transform.position, line.transform.position);

        MoveObjDist = (int)Vector3.Distance(MoveObj.transform.position, line.transform.position);

        if (ObjDist == MoveObjDist)
            DstCheck = true;
        else
            DstCheck = false;

        Debug.Log(DstCheck);

        Debug.Log("move:"+MoveObjDist);
        Debug.Log("obj:"+ObjDist);
    }
}
