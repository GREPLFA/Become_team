using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Orgel : MonoBehaviour
{
    public float timer;
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer < 0)
        {
            SceneManager.LoadScene("DeadScene");
        }
    }
}
