using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //PlayerMove pm = 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
