using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] float m_zoomSpeed = 0f;
    [SerializeField] float m_maxZoom = 0f;
    [SerializeField] float m_minZoom = 0f;

    void CameraZoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");  //ÁÜ °ª.

        if (transform.position.y <= m_maxZoom && t_zoomDirection > 0)
            return;
        if (transform.position.y >= m_minZoom && t_zoomDirection < 0)
            return;

        transform.position = transform.forward * t_zoomDirection * m_zoomSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        CameraZoom();
    }
}
