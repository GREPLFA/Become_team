using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadToMain : MonoBehaviour
{
    float timer;
    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3f)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
