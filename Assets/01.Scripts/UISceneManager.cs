using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet;
using FishNet.Managing.Scened;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public class UISceneManager : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("ServerScene");
    }
    
    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickStudyButton()
    {
        SceneManager.LoadScene("StudyScene");
    }
    
}
