using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
/*
적 유닛이 죽는 방식을 래그돌을 이용함
출처 : https://www.youtube.com/watch?v=KuMe6Iz8pFI

*/

public class Enemy : LivingEntity
{
    public LayerMask whatIsTarget;
    public Slider healthSlider;
    private LivingEntity targetEntity;
    private NavMeshAgent pathFinder;

    public ParticleSystem hitEffect;
    public AudioClip deathSound;
    public AudioClip hitSound;

    private Animator enemyAnimator;
    private AudioSource enemyAudioPlayer;
    private Renderer enemyRenderer;

    public float damage = 20f;
    public float timeBetAttack = 0.5f;

    private float lastAttackTime;

    private bool hasTarget
    {
        get
        {
            if(targetEntity != null && !targetEntity.dead)
            {
                return true;
            }

            return false;
        }
    }
    private bool Attack;


    //----
    private enum EnemyState
    {
        Walking,
        Ragdoll,
    }

    private Rigidbody[] ragdollRigiBoies;
    private EnemyState currentState = EnemyState.Walking;


    void Awake()
    {
        if(TryGetComponent(out NavMeshAgent v_navmeshAgent))
        {
            pathFinder = v_navmeshAgent;
        } else Debug.LogError("NavMeshAgent is null");
        if(TryGetComponent(out Animator v_animator))
        {
            enemyAnimator = v_animator;
        }else Debug.LogError("Animator is null");

        if(TryGetComponent(out AudioSource v_audioSource))
        {
            enemyAudioPlayer = v_audioSource;
        }else Debug.LogError("AudioSource is null");
        if(TryGetComponent(out Renderer v_renderer))
        {
            enemyRenderer = v_renderer;
        }else Debug.LogError("Renderer is null");


        ragdollRigiBoies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();

    }

private void DisableRagdoll()
{
    foreach(var rigid in ragdollRigiBoies)
    {
        rigid.isKinematic = true;
    }
    enemyAnimator.enabled = true;
}
private void EnableRagdoll()
{
    foreach(var rigid in ragdollRigiBoies)
    {
        rigid.isKinematic = false;
    }
    enemyAnimator.enabled = false;
}

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnimator.SetBool("HasTarget", hasTarget);
        enemyAnimator.SetBool("Attack", Attack);

    }

    private IEnumerator UpdatePath()
    {
        while(!dead)
        {
            if(hasTarget)
            {
                pathFinder.isStopped = false;
                pathFinder.SetDestination(targetEntity.transform.position);
                transform.rotation =
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetEntity.transform.position - transform.position),1);		


                float dir = Vector3.Distance(targetEntity.transform.position, transform.position);
                if(dir < 5)
                {
                    Attack = true;
                }
                else
                {
                    Attack = false;
                }
            }
            else
            {
                Debug.Log("not track");

                pathFinder.isStopped = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                for(int i = 0; i < colliders.Length; i++)
                {
                    LivingEntity livingEntity = colliders[i].GetComponent<LivingEntity>();

                    if(livingEntity != null && !livingEntity.dead)
                    {
                        targetEntity = livingEntity;
                        Debug.Log("finding" + targetEntity);

                        break;
                    }
                }
            }

            yield return new WaitForSeconds(0.25f);
        }
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        // if(!dead)
        // {
        //     hitEffect.transform.position = hitPoint;
        //     hitEffect.transform.rotation = Quaternion.LookRotation(hitNormal);
        //     hitEffect.Play();

        //     enemyAudioPlayer.PlayOneShot(hitSound);
        // }

        base.OnDamage(damage, hitPoint, hitNormal);
        healthSlider.value = health;
    }

    public override void Die()
    {
        base.Die();

        Collider[] enemyColliders = GetComponents<Collider>();
        for(int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        healthSlider.gameObject.SetActive(false);
        pathFinder.isStopped = true;
        pathFinder.enabled = false;

        EnableRagdoll();
        // enemyAudioPlayer.PlayOneShot(deathSound);

        Destroy(gameObject, 5f);
    }

    private void OnTriggerStay(Collider other) {
        if(!dead && Time.time >= lastAttackTime + timeBetAttack)
        {
            LivingEntity attackTarget = other.GetComponent<LivingEntity>();

            if(attackTarget != null && attackTarget == targetEntity)
            {
                lastAttackTime = Time.time;

                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitNormal = other.transform.position;

                attackTarget.OnDamage(damage, hitPoint, hitNormal);
            }
        }    
    }
}
