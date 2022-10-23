using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBrick : MonoBehaviour
{
    public float hp = 100;
    public static bool Active = true;
    public AudioClip WoodDestroyClip;
    public AudioClip AttackClip;

    public void Damage(float amount)
    {
        if(hp <= 0)
        {
            return;
        }
        hp -= amount;
        if(hp <= 0)
        {
            SoundManager.instance.SFXPlay("WoodDestroy", WoodDestroyClip);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Damage(50);
            SoundManager.instance.SFXPlay("Attack", AttackClip);
        }
    }
}
