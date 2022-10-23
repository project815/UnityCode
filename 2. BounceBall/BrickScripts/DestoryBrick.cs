using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBrick : MonoBehaviour
{
    public float destroryTime;
    public static bool Active = true;

    bool isPlayer = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayer = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isPlayer == true)
        {
            Destroy(gameObject, destroryTime);
            isPlayer=false;
        }
    }
    void OnDisable()
    {
        Active = false;
    }
}
