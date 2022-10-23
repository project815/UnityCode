using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : MonoBehaviour
{
    public GameObject[] Lock;

    int number;

    int ReLoadNumber;
    void Start()
    {
        number = PlayerPrefs.GetInt("stagenum"); //gameclear
        ReLoadNumber = PlayerPrefs.GetInt("Loadnum"); //reload
    }
    private void Update()
    {
        //restart
        if (ReLoadNumber <= number)
        {
            ReLoadNumber = number;
            PlayerPrefs.SetInt("Loadnum", ReLoadNumber);
        }


        for (int i = 0; i < Lock.Length; i++)
        {
            if (i <= ReLoadNumber)
            {
                Lock[i].SetActive(false);
            }
        }

    }

}
