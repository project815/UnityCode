using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Ʈ�������� ȸ��
ȸ���� ���� ����
https://ssabi.tistory.com/24
 */

public class BillBoard : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
