using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBrick : MonoBehaviour
{
    public AudioClip JumpClip;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerMove.JumpPower += 2;
            SoundManager.instance.SFXPlay("Jump", JumpClip);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerMove.JumpPower -= 2;
        }
    }
}
