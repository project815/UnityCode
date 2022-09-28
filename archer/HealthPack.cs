using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour, Item
{
    public float health = 20f;

    public void Use(GameObject target)
    {
        LivingEntity life = target.GetComponent<LivingEntity>();

        if(life != null)
        {
            Debug.Log("HealthPack");
            life.RestroeHealth(health);
        }

        Destroy(gameObject);
    }
}
