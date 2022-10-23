using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;


    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    AudioSource ShootSound;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerMove>().transform;
        ShootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(new Vector3(90, 0, 90)));
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            ShootSound.PlayOneShot(ShootSound.clip, 1f);
        }
    }
}
