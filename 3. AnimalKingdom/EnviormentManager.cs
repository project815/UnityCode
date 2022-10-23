using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviormentManager : MonoBehaviour
{
    public GameObject forest;
    public GameObject desert;
    public GameObject grass;
    

    public GameObject Animal_level1;
    public GameObject Animal_level2;
    public GameObject Animal_level3;
    public GameObject Animal_level4;
    public GameObject Animal_level5;
    public GameObject Animal_level6;

    public GameObject Rain;

    int forest_count;
    int desert_count;
    int grass_count;

    bool overlapStop;


    // Start is called before the first frame update
    void Awake()
    {
        overlapStop = false;
        forest_count = forest.transform.childCount;
        desert_count = desert.transform.childCount;
        grass_count = grass.transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMessager.val == 0 ) level_1();
        if (PlayerMessager.val == 1) level_2();
        if (PlayerMessager.val == 2) level_3();
        if (PlayerMessager.val == 3) level_4();
        if (PlayerMessager.val == 4) level_5();
        if (PlayerMessager.val == 5) level_6();
        if (PlayerMessager.val == 6) Final();
    }

    void level_1()
    {
        for (int i = 0; i < desert_count / 2; i++)
        {
            desert.transform.GetChild(i).gameObject.SetActive(true);
        }
        Animal_level1.SetActive(true);
    }
    void level_2() 
    {

        for (int i = 0; i < desert_count; i++)
        {
            desert.transform.GetChild(i).gameObject.SetActive(true);
        }
        Animal_level1.SetActive(true);
        Animal_level2.SetActive(true);

    }
    void level_3()
    {
        for (int i = 0; i < forest_count/14; i++)
        {
            forest.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < grass_count/5; i++)
        {
            grass.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < desert_count/4; i++)
        {
            desert.transform.GetChild(i).gameObject.SetActive(true);
        }
        Animal_level1.SetActive(true);
        Animal_level2.SetActive(true);
        Animal_level3.SetActive(true);
        Rain.SetActive(true);
    }
    void level_4()
    {
        for (int i = 0; i < forest_count/5; i++)
        {
            forest.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < grass_count/5; i++)
        {
            grass.transform.GetChild(i).gameObject.SetActive(true);
        }
        Animal_level2.SetActive(true);
        Animal_level3.SetActive(true);
        Animal_level4.SetActive(true);
    }
    void level_5()
    {
        for (int i = 0; i < forest_count/2; i++)
        {
            forest.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < grass_count; i++)
        {
            grass.transform.GetChild(i).gameObject.SetActive(true);
        }

        Animal_level2.SetActive(true);
        Animal_level3.SetActive(true);
        Animal_level4.SetActive(true);
        Animal_level5.SetActive(true);
        Rain.SetActive(true);

    }
    void level_6()
    {
        for (int i = 0; i < forest_count; i++)
        {
            forest.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < grass_count; i++)
        {
            grass.transform.GetChild(i).gameObject.SetActive(true);
        }

        Animal_level2.SetActive(true);
        Animal_level3.SetActive(true);
        Animal_level4.SetActive(true);
        Animal_level5.SetActive(true);
        Animal_level6.SetActive(true);

    }
    void Final()
    {
        for (int i = 0; i < forest_count; i++)
        {
            forest.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < grass_count; i++)
        {
            grass.transform.GetChild(i).gameObject.SetActive(true);
        }

        Animal_level1.SetActive(true);
        Animal_level2.SetActive(true);
        Animal_level3.SetActive(true);
        Animal_level4.SetActive(true);
        Animal_level5.SetActive(true);
        Animal_level6.SetActive(true);
    }
}
