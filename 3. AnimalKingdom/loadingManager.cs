using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingManager : MonoBehaviour
{
    public GameObject SceneManager;
    public GameObject ObjBackGround;
    public RawImage imgBackGround;
    float timer;
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            imgBackGround.color = Color.Lerp(imgBackGround.color, new Color(0, 0, 0, 0), 0.01f);
        }
        if(timer > 10)
        {
            gameObject.SetActive(false);

        }
        else
        {
            imgBackGround.color = new Color(0, 0, 0, 1);
        }
    }
    
}
