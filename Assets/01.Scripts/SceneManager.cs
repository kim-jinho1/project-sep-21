using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet;
using FishNet.Managing.Scened;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }


    private void Update()
    {

    }

    public void OnClickStartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ServerScene");
    }
    
    public void OnClickExitButton()
    {
        Application.Quit();
    }
    
}
