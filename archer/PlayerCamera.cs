using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    private PlayerInput input;

    [Header("CameraSetting")]
    public CinemachineFreeLook cinemachineFreeLook;
    public float originalFieldView = 60f;
    public float zoomFieldView = 30f;
    public float zoomSpeed = 0.5f;

    //CameraMove

    void Awake()
    {
        if(TryGetComponent<PlayerInput>(out PlayerInput v_playerInput))
            input = v_playerInput;
    }

    void Update()
    {
        if(input == null)
        {
            Debug.Log("PlayerInput is null");
            return;
        }
        CameraMove();
        // ZoomCamera();
    }

    //카메라 이동
    public void CameraMove()
    {
        if(input.Touching)
        {        
            cinemachineFreeLook.m_YAxis.m_InputAxisName = "Mouse Y";
            cinemachineFreeLook.m_XAxis.m_InputAxisName = "Mouse X";
        }
        if(input.TouchUp)
        {
            cinemachineFreeLook.m_YAxis.m_InputAxisName = "";
            cinemachineFreeLook.m_XAxis.m_InputAxisName = "";
            cinemachineFreeLook.m_YAxis.m_InputAxisValue = 0;
            cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0;
        }
    }
    ///카메라 줌인
    // public void ZoomCamera()
    // {
    //     if(input.isAim)
    //     {
    //         cinemachineFreeLook.m_Lens.FieldOfView = Mathf.Lerp(cinemachineFreeLook.m_Lens.FieldOfView, zoomFieldView, zoomSpeed * Time.deltaTime);
    //     }
    //     else
    //     {
    //         cinemachineFreeLook.m_Lens.FieldOfView = Mathf.Lerp(cinemachineFreeLook.m_Lens.FieldOfView, originalFieldView, zoomSpeed* Time.deltaTime);
    //     }
    // }
}
