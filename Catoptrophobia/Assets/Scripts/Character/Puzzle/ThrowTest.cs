using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTest : MonoBehaviour
{
    bool throwed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.parent = null;
            transform.GetComponent<BoxCollider>().enabled = false;
            throwed = true;
        }

        if (throwed)
        {
            transform.GetComponent<BoxCollider>().enabled = true;
            throwed = false;
        }
    }

}
