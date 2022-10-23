using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introball : MonoBehaviour
{
    bool isPlayer;
    AudioSource Audio;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Audio = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "JumpPos")
        {
            isPlayer = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isPlayer == true)
        {
            Audio.PlayOneShot(Audio.clip, 1f);
            isPlayer = false;
            rigid.AddForce(Vector3.up * 2);
        }
        
    }
}
