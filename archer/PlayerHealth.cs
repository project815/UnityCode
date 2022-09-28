using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : LivingEntity
{
    
    public Slider healthSlider;
    
    //사운드
    public AudioClip deathCilp;
    public AudioClip hitClip;
    public AudioClip itemPickClip;

    private AudioSource audioSource;
    private Animator anim;

    private PlayerMovement playerMovement;
    private PlayerShooter playerShooter;

    private void Awake()
    {
        if(TryGetComponent(out Animator v_animator))
        {
            anim = v_animator;
        }
        if(TryGetComponent(out AudioSource v_audiosoure))
        {
            audioSource = v_audiosoure;
        }

        if(TryGetComponent(out PlayerMovement v_playerMovement))
        {
            playerMovement = v_playerMovement;
        }
        if(TryGetComponent(out PlayerShooter v_playerShooter))
        {
            playerShooter = v_playerShooter;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        healthSlider.gameObject.SetActive(true);
        healthSlider.maxValue = startingHealth;
        healthSlider.value = health;

        playerMovement.enabled =true;
        playerShooter.enabled = true;
    }

    public override void RestroeHealth(float newHealth)
    {
        base.RestroeHealth(newHealth);
        healthSlider.value = health;
        Debug.Log("PlayerHealth : health =  " +  health + "healthSlider.value : " + healthSlider.value);
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        // if(!dead)
        // {
        //     audioSource.PlayOneShot(hitClip);
        // }
        Debug.Log("sdfsadfs");
        base.OnDamage(damage, hitPoint, hitDirection);
        healthSlider.value = health;
    }

    public override void Die()
    {
        base.Die();

        // healthSlider.gameObject.SetActive(false);

        audioSource.PlayOneShot(deathCilp);
        anim.SetTrigger("Die");

        playerMovement.enabled = false;
        playerShooter.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(!dead)
        {
            Item item = other.GetComponent<Item>();

            if(item != null)
            {
                Debug.Log("PlayerHealth : ");
                item.Use(gameObject);
                // audioSource.PlayOneShot(itemPickClip);
            }
        }
    } 
}
