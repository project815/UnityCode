using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
참고자료 : 
1. Cooldown UI : https://www.youtube.com/watch?v=1fBKVWie8ew

*/

public class ModeChanger : MonoBehaviour
{
    public PlayerInput playerInput;

    [Header("ModeChnageButton")]
    public GameObject selectedButtonIndicator;

    //무슨 모드인지?
    public bool isAimMode{get; private set;} //걷는지 조준하고 있는지?
    public bool isRunMode{get; private set;} //걷는지 뛰는지
    
    [Header("RunMode & CooldownTime")]
    public GameObject runMode;
    [SerializeField] private Image image_Cooldown;
    [SerializeField] private TMP_Text text_Cooldown;
    [SerializeField] private ParticleSystem particleSystem_Run;
    //쿨타임 변수
    private bool isCooldown = false;
    private float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;


    void Awake()
    {
        //쿨타임 초기화
        text_Cooldown.gameObject.SetActive(false);
        image_Cooldown.fillAmount = 0.0f;
    }

    void Update()
    {
        //CoolTime  >> 네트워크 구현?!? 호스트 판정?!
        if(isCooldown)
        {
            ApplyCooldown();
        }
    }
    //쿨타임 시간
    void ApplyCooldown()
    {
        //subtrack time since last called.
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer < 0.0f)
        {
            isCooldown = false;
            particleSystem_Run.gameObject.SetActive(false);
            text_Cooldown.gameObject.SetActive(false);
            image_Cooldown.fillAmount = 0.0f;

             isRunMode = false;
        }

        else //쿨타임동안 실행되는 내용.
        {
            text_Cooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            image_Cooldown.fillAmount = cooldownTimer / cooldownTime;

            isRunMode = true;
        }
    }

    public void UseSpell()
    {
        if(isCooldown)
        {
            //user clicked spell while in use
        }
        else
        {
            isCooldown = true;
            particleSystem_Run.gameObject.SetActive(true);
            text_Cooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
        }
    }

    //모드 변경 (걷기 모드 & 조준모드)
    public void ModeChange(bool ActiveAim)
    {
        isAimMode = ActiveAim;
        selectedButtonIndicator.SetActive(isAimMode);
    }

}
