using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{

    bool isPlayer = false;

    public AudioClip StarInputClip;
    
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
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        if(isPlayer == true)
        {
            SoundManager.instance.SFXPlay("StarInput", StarInputClip);
            Destroy(gameObject);
        }
    }
    
}
