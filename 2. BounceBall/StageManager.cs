using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public int StageClearNumber;

    public GameObject GameClearButton;


    GameObject BulletEnemy;
    AudioSource SoundManAudio;
    

    public bool isPlayer;
    int overlapPrevent = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayer = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayer = false;
        }
    }
    void Start()
    {
        isPlayer = false;
        //SoundManAudio = GameObject.Find("SoundManager");
        SoundManAudio = FindObjectOfType<SoundManager>().GetComponent<AudioSource>();
        BulletEnemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    void Update()
    {
        if(isPlayer == true && StarInput.starCount <= 0 && overlapPrevent == 0)
        {
            StageSave();

            Time.timeScale = 0;
            GameClearButton.SetActive(true);
            //SoundManAudio.GetComponent<AudioSource>().Pause();
            isPlayer = false;
            overlapPrevent = 1;
            if(BulletEnemy != null)
            BulletEnemy.SetActive(false);
        }
        
    }
    void StageSave()
    {
        PlayerPrefs.SetInt("stagenum", StageClearNumber);
    }
}
