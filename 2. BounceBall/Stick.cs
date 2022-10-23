using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler //???????? ???? ???????? ?? ???????? ?????? ????.
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10, 150)]
    private float leverRange;

    private Vector2 inputDirection;
    private bool isInput;



    [SerializeField]
    private PlayerMove controller;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoyStickLever(eventData);
        isInput = true; 
    }
    //?????????? ???????? ?????? ???? ?????? ???????? ??????
    //?????? ?????? ?????? ?????? ???????? ?????? ???????? ???????? ????.

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoyStickLever(eventData);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        //controller.Move(Vector2.zero);
    }

    private void ControlJoyStickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }

    private void InputControlVector()
    {
        //?????????? ?????????? ????
        //controller.Move(inputDirection);
        Debug.Log(inputDirection.x + " / " + inputDirection.y);
    }

    void Update()
    {
        if(isInput)
        {
            InputControlVector();
        }
    }

}
