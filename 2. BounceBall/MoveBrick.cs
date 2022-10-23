using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBrick : MonoBehaviour
{
    public Transform []Pos;

    int i = 0;
    private void Start()
    {
    }
    void Update()
    {
        float dist = Vector3.Distance(transform.position, Pos[i].position);
        if(dist <= 1)
        {
            if(++i >=Pos.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, Pos[i].position, 0.03f);

        //for(int i = 0; i < pos.Length; i++)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pos[i].position, 1f);

        //    if (transform.position == pos[i].position)
        //    {
        //        i += 1;
        //        if(i >= pos.Length)
        //        {
        //            i = 0;
        //        }
        //    }
        //}
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 19f), 0.01f);

        //MoveToward
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f);

        //SmoothDamp ref, out ??????????.
        //Vector3 velo = Vector3.zero;
        //Vector3 velo = Vector3.up * 50;
        //transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 1f);

        //Lerp : SmoothDamp???? ?????????? ??.
        //for (int i = 0; i < Pos.Length; i++)
        //{

        //    if (transform.position == Pos[i].position)
        //    {
        //        i++;
        //        if (i > Pos.Length)
        //        {
        //            i = 0;
        //        }
        //    }

        //}

    }
}
