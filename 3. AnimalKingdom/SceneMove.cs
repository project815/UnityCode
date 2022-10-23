using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SceneMove : MonoBehaviour
{
    public int sceneNunmer;

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void LoadScene(string scnenName)
    {
        SceneManager.LoadScene(scnenName);
        Load_Initilalize();
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void Load_Deintiailize()
    {
        LoaderUtility.Deinitialize();
    }
    public void Load_Initilalize()
    {
        LoaderUtility.Initialize();
    }
    
}
