using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultiJoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler

{
    public Transform player;
    public float speed;
    float hAxis;
    float vAxis;
    Vector3 moveVec;
    public RectTransform pad;
    public RectTransform stick;

    public void OnDrag(PointerEventData eventData)
    {
        stick.position = eventData.position;

        stick.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);

        //move = new Vector3(stick.localPosition.x, 0, stick.localPosition.y).normalized;

        //float xInput = stick.localPosition.magnitude;

        //Debug.Log("xInput : " + xInput);
        //Debug.Log("y : " + stick.localPosition.y);
        hAxis = stick.localPosition.x;
        vAxis = stick.localPosition.y;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pad.position = eventData.position;
        pad.gameObject.SetActive(true);
        StartCoroutine("Movement");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.localPosition = Vector3.zero;
        pad.gameObject.SetActive(false);
        StopCoroutine("Movement");
        moveVec = Vector3.zero;
    }

    IEnumerator Movement()
    {
        while(true)
        {
            moveVec = new Vector3(hAxis, 0, vAxis).normalized;
            transform.position += (speed * moveVec * Time.deltaTime);
            transform.LookAt(transform.position + moveVec);

            //player.GetComponent<Rigidbody>().velocity = moveVec;

            //player.Translate(move * speed * Time.deltaTime); 

            //if(move != Vector3.zero)
            //    player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);
            yield return null; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
