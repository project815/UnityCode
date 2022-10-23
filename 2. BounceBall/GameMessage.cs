using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMessage : MonoBehaviour
{
    Text GM;

    public float timer;
    public GameObject Bircks;
    public GameObject NextStage;

    bool forward;
    bool backward;
    bool left;
    bool right;


    void IsPlayerMoving()
    {
        if(PlayerMove.vAxis > 0)
        {
            forward = true;
        }
        if(PlayerMove.vAxis < 0)
        {
            backward = true;
        }
        if(PlayerMove.hAxis > 0)
        {
            left = true;
        }
        if(PlayerMove.hAxis < 0)
        {
            right= true;
        }
    }
    void Start()
    {
        GM = GetComponent<Text>();
    }

    void Update()
    {
        IsPlayerMoving();

        timer += Time.deltaTime;
        if(0 < timer&&timer < 5)
        {
            GM.text = "Welcome"; 
            forward = false;
            backward = false;
            left = false;
            right = false;
        }
        else if(5< timer && timer < 10)
        {
            GM.text = "Try to Move";
            forward = false;
            backward = false;
            left = false;
            right = false;
        }
        
        else if(forward == true && backward == true && left == true && right == true)
        {
            Bircks.SetActive(true);
            GM.text = "Good! Figure The Type of Bricks Out!";
        }
    }

}