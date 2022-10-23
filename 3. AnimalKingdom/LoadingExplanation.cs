using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingExplanation : MonoBehaviour
{
    Text loadingmessage;
    
    // Start is called before the first frame update
    void Start()
    {
        loadingmessage = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMessager.val == 0)
            loadingmessage.text = "AR ������ �ձ��� ���� ���� ȯ���մϴ�.\n\n�� ������ ������ ã�� ��� ���糪���� �н��� ���Դϴ�.\n\n����, �縷�� ��� �ִ� ������ ã�ƺ�����!.";
        if (PlayerMessager.val == 1)
            loadingmessage.text = "���߾��!.\n\n��� ���� ���� �ܰ�� �Ѿ�ϴ�.\n\n�̹��� ã�� ������ ũ�Ⱑ �۽��ϴ�.\n\n�� ã�ƺ�����!.";
        if (PlayerMessager.val == 2)
            loadingmessage.text = "���߾��!.\n\n�� �ͼ� ���� Ǯ�� �ڶ󳪰� �־��.\n\n�̹��� ã�� ������ ũ�Ⱑ ���� Ů�ϴ�.\n\n���� ��ٶ� �ڸ� ������ �ִ� �� ������ ã�ƺ�����";
        if (PlayerMessager.val == 3)
            loadingmessage.text = "���ƿ�!.\n\n�� ��ġ�� ���� ������ �ڶ󳪰� �־��.\n\n�̹��� �ڿ� ���� �޸� ������ ã�ƺ��ô�!.\n\n���ݸ� �� ���� ������.";
        if (PlayerMessager.val == 4)
            loadingmessage.text = "���ϰ� �־��.\n\n�� �ٽ� ���� �����߾��.\n\n�������� �ʽĵ���, ���ĵ����� �־��.\n\n�̹��� ���ĵ����� ã�ƺ�����.";
        if (PlayerMessager.val == 5)
            loadingmessage.text = "�Ǹ��մϴ�!.\n\n���� ������ �ܰ迡 �Խ��ϴ�.\n\n���� ����, �� ���̸� ������ �ִ� ������ ã�ƺ�����.";
        if (PlayerMessager.val == 6)
            loadingmessage.text = "���߾��.\n\n��� ������ ������ϴ�.\n\n���ƴٴϸ鼭 �������� �����غ�����.";
    }
}
