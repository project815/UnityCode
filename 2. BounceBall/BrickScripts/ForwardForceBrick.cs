using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardForceBrick : MonoBehaviour
{
    public float Power;
    Rigidbody rigid;

    AudioSource ShootClip;

    bool isPlayer;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayer = true;
            //PlayerMove.JumpPower += 100f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = GameObject.Find("Player").GetComponent<Rigidbody>();
        ShootClip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
        {
            rigid.AddForce(transform.forward * Power, ForceMode.Impulse);
            ShootClip.PlayOneShot(ShootClip.clip, 1f);
            isPlayer = false;
        }
    }
}
