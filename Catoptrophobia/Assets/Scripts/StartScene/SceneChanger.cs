using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneChanger : MonoBehaviour
{

    public void ClickStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void ClickQuit()
    {
        Application.Quit();
    }
}
