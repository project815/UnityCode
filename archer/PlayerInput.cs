using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/*
참고자료 :
1. 레트로 playerInput
2. [System.SerializeField]로 묶어서 사용, 화살쏘기 시스템
 : https://www.youtube.com/watch?v=IRT-GAxWFyY&list=PLLMGaKJ8ODghM_kq_L5Sf7t_uqoqLqvMG&index=11
*/

public class PlayerInput : MonoBehaviour
{
    #region 변수
    [Header("InputManagerSettings")]
    [SerializeField]private JoyStickInputManager joystick;
    [SerializeField]private ModeChanger modeChanger;
    private PlayerString PString;

    //캐릭터 움직임
    public float horizontal { get; private set; } // 감지된 좌우 입력값
    public float vertical { get; private set; } // 감지된 앞뒤 입력값

    //캐릭터 달리기
    public bool isMove {get; private set; }
    public bool isRun {get; private set; }


    //조준
    public bool isAim{ get; private set; }
    public bool isPull{ get; private set; }
    public bool isFire { get; private set; }

    //터치를 활용해서 카메라, 조준 밋 공격
    public bool TouchDown{get; private set;}
    public bool Touching {get; private set; }
    public bool TouchUp {get; private set;}

    #endregion
    
    void Awake()
    {
        if(TryGetComponent<PlayerString>(out PlayerString v_playerString))  {
            PString = v_playerString;           
        }    
    }
    void Update()
    {
        if(PString ==null)
        {
            Debug.Log("PlayerString is null");
            return;
        }

        if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            horizontal = 0f;
            vertical = 0f;
            return;
        }
        else
        {
            Move();
            Fire();
            Touch();
        }
    }

    private void Move()
    {
        if(PString == null)
        {
            Debug.Log("PlayerString is null");
            return;
        }
        if(joystick == null)
        {
            Debug.Log("ModeChanger is null");
            return;
        }
        //모바일용
        horizontal = joystick.inputDirection.x + Input.GetAxis(PString.rightInput);
        vertical = joystick.inputDirection.y + Input.GetAxis(PString.forwardInput);
        
        if(new Vector3(vertical, 0, horizontal).magnitude > 0) isMove = true;
        else isMove = false;

        if(modeChanger.isRunMode) isRun = true;
        else isRun = false;
    }

    private void Fire()       
    {
        isFire = CrossPlatformInputManager.GetButtonUp(PString.fire);
    }

    private void Touch()
    {        
        TouchDown = CrossPlatformInputManager.GetButtonDown(PString.touch);
        Touching = CrossPlatformInputManager.GetButton(PString.touch);
        TouchUp = CrossPlatformInputManager.GetButtonUp(PString.touch);

        if(modeChanger.isAimMode)
        {
            isAim = Touching;
            isPull = Touching;
            isFire = TouchUp;
        }
    }
}
