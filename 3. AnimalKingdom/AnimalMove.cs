using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMove : MonoBehaviour
{

    //AnimalMove    
    NavMeshAgent nav;

    public Transform[] pos;
    int i; // animal Position
    int j; // animal Move time

    float time;

    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        i = Random.Range(0, pos.Length);
        j = Random.Range(20, 30);
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
     {
    //     time += Time.deltaTime;

    //     if (time > j)
    //     {
    //         i = Random.Range(0, pos.Length);
    //         time = 0;
    //     }
    //     nav.SetDestination(pos[i].position);

    //     float dist = Vector3.Distance(transform.position, pos[i].position);

    //     anim.SetBool("isMove", dist >= 1 ? true : false);
    }
}
