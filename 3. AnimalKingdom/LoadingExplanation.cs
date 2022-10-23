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
            loadingmessage.text = "AR 동물의 왕국에 오신 것을 환영합니다.\n\n본 게임은 동물을 찾아 퀴즈를 맞춰나가는 학습용 앱입니다.\n\n먼저, 사막에 살고 있는 동물을 찾아보세요!.";
        if (PlayerMessager.val == 1)
            loadingmessage.text = "잘했어요!.\n\n퀴즈를 맞춰 다음 단계로 넘어갑니다.\n\n이번에 찾을 동물은 크기가 작습니다.\n\n잘 찾아보세요!.";
        if (PlayerMessager.val == 2)
            loadingmessage.text = "잘했어요!.\n\n비가 와서 점점 풀이 자라나고 있어요.\n\n이번에 찾을 동물은 크기가 아주 큽니다.\n\n아주 기다란 코를 가지고 있는 이 동물을 찾아보세요";
        if (PlayerMessager.val == 3)
            loadingmessage.text = "좋아요!.\n\n비가 그치고 점점 나무가 자라나고 있어요.\n\n이번엔 코에 뿔이 달린 동물을 찾아봅시다!.\n\n조금만 더 힘을 내봐요.";
        if (PlayerMessager.val == 4)
            loadingmessage.text = "잘하고 있어요.\n\n비가 다시 오기 시작했어요.\n\n동물에는 초식동물, 육식동물이 있어요.\n\n이번엔 육식동물을 찾아보세요.";
        if (PlayerMessager.val == 5)
            loadingmessage.text = "훌륭합니다!.\n\n인제 마지막 단계에 왔습니다.\n\n검은 무늬, 흰 무늬를 가지고 있는 동물을 찾아보세요.";
        if (PlayerMessager.val == 6)
            loadingmessage.text = "잘했어요.\n\n모든 정답을 맞췄습니다.\n\n돌아다니면서 동물들을 관찰해보세요.";
    }
}
