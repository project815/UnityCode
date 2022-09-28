using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }
    private static GameManager m_instance;
    private int score = 0;
    public bool isGameover {get; private set;}
    
    public void SceneMove(string SceneName)
    {
        LoadingSceneController.LoadScene(SceneName);
    }
}
