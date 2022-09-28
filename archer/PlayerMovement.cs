using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    #region 변수
    private Rigidbody rigid;
    private PlayerInput input;
    private Animator animator;
    private PlayerString PString;
    private Transform cam;

    [Header("PlayerControl")]
    public float speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
#endregion

    #region 초기화
    void Awake()
    {
        if(TryGetComponent<PlayerInput>(out PlayerInput v_playerInput))
            input = v_playerInput;
        if(TryGetComponent<Animator>(out Animator v_animator))
            animator = v_animator;
        if(TryGetComponent<Rigidbody>(out Rigidbody v_rigidbody))
            rigid = v_rigidbody;
        if(TryGetComponent<PlayerString>(out PlayerString playerString))
            PString = playerString;           
        
        cam = Camera.main.transform;
    }
    #endregion

    private void Update() {
        if(input == null)
        {
            Debug.Log("PlayerInput is null");
            return;
        }
        if(animator == null)
        {
            Debug.Log("Animator is null");
            return;
        }
        if(rigid == null)
        {
            Debug.Log("Rigidbody is null");
            return;
        }
        if(PString == null)
        {
            Debug.Log("PlayerString is null");
            return;
        }
        Rotate(); 
        MoveAnim();
    }

    private void Rotate()
    {
        //캐릭터 움직임(속도 및 방향, 카메라 회전으로 캐릭터 돌림.)
        Vector3 MoveVec = new Vector3(input.horizontal, 0, input.vertical).normalized;
        
        float targetAngle = cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
    private void MoveAnim()
    {
        //애니메이션(이동) - use apply root motion
        animator.SetFloat("Vertical", input.vertical);
        animator.SetFloat("Horizontal", input.horizontal);
        //걷기/뛰기
        animator.SetBool(PString.bool_run, input.isRun);
    }
}
