using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Animal : MonoBehaviour
{
    

    private static Animal instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private void OnEnable()
    {
        
    }
}
