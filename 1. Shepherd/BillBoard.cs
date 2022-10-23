using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
트랜스폼과 회전
회전에 관한 정보
https://ssabi.tistory.com/24
 */

public class BillBoard : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
