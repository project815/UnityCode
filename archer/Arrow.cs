using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rigid;
    BoxCollider boxCollider;
    bool disableRotation;


    void Awake()
    {
        if(TryGetComponent<Rigidbody>(out Rigidbody v_rigidbody))
        {
            rigid = v_rigidbody;
        }
        if(TryGetComponent<BoxCollider>(out BoxCollider v_boxCollider))
        {
            boxCollider = v_boxCollider;
        }
    }
    void Update()
    {
        if(!disableRotation)
            transform.rotation = Quaternion.LookRotation(rigid.velocity);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //데미지 주기
        //렉돌에 화살 박기
        //메인콜라이더에서는 지나치기
        //이외에 지형에 닿으면 멈추기

        if(collision.gameObject.tag != "Player")
        {
            //데미지 주기
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();

            if(target != null)
            {
                Debug.Log("target");
                target.OnDamage(50, collision.transform.position, collision.contacts[0].normal);
            }
            else
            {
                Debug.Log("target is not");
                transform.parent = collision.gameObject.transform;
                ArrowStop();
            }
        }
    }

    public void ArrowStop()
    {
        disableRotation = true;
        rigid.isKinematic = true;
        boxCollider.enabled = false;
    }
}
