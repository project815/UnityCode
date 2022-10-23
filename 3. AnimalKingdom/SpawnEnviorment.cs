using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnviorment: MonoBehaviour
{
    public GameObject[] desert_Enviorment;
    public GameObject[] forest_Enviorment;
    public GameObject[] grass_Enviorment;
    public GameObject[] rock_Enviorment;
    public GameObject[] cactus_Enviorment;

    bool overlapStop_desert;
    bool overlapStop_forest;
    bool overlapStop_grass;
    bool overlapStop_rock;

    void Awake()
    {

        overlapStop_desert = false;
        overlapStop_forest = false;
        overlapStop_grass = false;
        overlapStop_rock = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (desert_Enviorment.Length > 0)
        {
            Desert_Enviorment();
        }
        if (grass_Enviorment.Length > 0)
        {
            Grass_Enviorment();
        }
        if (forest_Enviorment.Length > 0)
        {
            Forest_Enviorment();
        }
        if(rock_Enviorment.Length > 0)
        {
            Rock_Enviorment();
        }


    }

    void Desert_Enviorment()
    {
        if (!overlapStop_desert)
        {
            int random_num = Random.Range(0, desert_Enviorment.Length);
            Instantiate(desert_Enviorment[random_num], transform.position, transform.rotation);
            overlapStop_desert = true;
        }
    }
    void Forest_Enviorment()
    {
        if (!overlapStop_forest)
        {
            int random_num = Random.Range(0, forest_Enviorment.Length);
            Instantiate(forest_Enviorment[random_num], transform.position, transform.rotation);
    
            overlapStop_forest = true;
        }
    }
    void Grass_Enviorment()
    {
        if (!overlapStop_grass)
        {
            int random_num = Random.Range(0, grass_Enviorment.Length);
            Instantiate(grass_Enviorment[random_num], transform.position + new Vector3(0, 0, 0), transform.rotation);
            Instantiate(grass_Enviorment[random_num], transform.position + new Vector3(5, 0, 0), transform.rotation);
            Instantiate(grass_Enviorment[random_num], transform.position + new Vector3(3, 0, 3), transform.rotation);
            Instantiate(grass_Enviorment[random_num], transform.position + new Vector3(5, 0, 1), transform.rotation);
       
            overlapStop_grass = true;
        }
    }

    void Rock_Enviorment()
    {
        if (!overlapStop_rock)
        {
            int random_num = Random.Range(0, rock_Enviorment.Length);
            Instantiate(rock_Enviorment[random_num], transform.position, transform.rotation);

            overlapStop_rock = true;
        }
    }

    void OnDrawGizmos()
    {
        if (desert_Enviorment.Length > 0) 
        {
            Gizmos.color = new Color32(255, 150, 0, 255); // low green
            Gizmos.DrawSphere(transform.position, 10);
        }
        if (forest_Enviorment.Length > 0)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(transform.position, new Vector3(10, 30, 10)); 

        }
        if(grass_Enviorment.Length > 0)
        {
            Gizmos.color = new Color32(167, 212, 111, 255); // low green
            Gizmos.DrawSphere(transform.position, 10);

        }
        if (rock_Enviorment.Length > 0)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawCube(transform.position, new Vector3(20 ,20,20));
        }
    }
}
