using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼수 있는 기능을 지원


public class JoyStickInputManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Lever")] //라벨 및 범위.
    [SerializeField]
    private RectTransform lever; 
    private RectTransform rectTransform;
    [SerializeField, Range(10, 150)] 
    private float leverRange;

    [HideInInspector] //입력받은 값.
    public Vector2 inputDirection;
    private bool isInput;
    
    [Space(10f)]
    [Header("Indicator")]
    public GameObject[] dirindicator;


    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }
    
    private void FixedUpdate() {
        if(isInput)
        {
            InputControlVector();

        }    
        else 
        {
            for(int i = 0; i < dirindicator.Length; i++)
            {
                dirindicator[i].SetActive(false);
            }
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoyStickLever(eventData);
        isInput = true;
    }

    //OnDrag함수의 주요한 특징!
    //오브젝트를 클릭해서 드래그 하는 도중에 들어오는 이벤트
    //하지만 클릭을 유지한 상태로 마우스를 멈추면 이벤트가 들어오지 않는다는 특징이 있다.
    //그래서 불리언 isInput을 따로 만들어 마우스의 움직임이 멈췄을 때도 꾸준히 값을 입력받기 위해서 InputControlVector()함수를 따로 만든 것이다.
    
    public void OnDrag(PointerEventData eventData)
    {
        ControlJoyStickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        inputDirection = Vector2.zero;
    }
    //ControlJoyStickLever 범위
    private void ControlJoyStickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition; //lever의 위치를 만들어줌.
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange; 
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange; //inputVector의 값이 너무 크기 떄문에 이대로 플레이어에 값을 대입하면 너무빠르게 움직임
    }

    #region Indicator
    public void InputControlVector()
    {
        //indicator 감지 활성화 및 비활성화
        if(inputDirection.x < 0 && inputDirection.y > 0) dirindicator[0].SetActive(true);
        else dirindicator[0].SetActive(false);

        if(inputDirection.x > 0 && inputDirection.y > 0) dirindicator[1].SetActive(true);
        else dirindicator[1].SetActive(false);

        if(inputDirection.x > 0 && inputDirection.y < 0) dirindicator[2].SetActive(true);
        else dirindicator[2].SetActive(false);

        if(inputDirection.x < 0 && inputDirection.y < 0) dirindicator[3].SetActive(true);
        else dirindicator[3].SetActive(false);


    }

    #endregion
}
