using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInsideMinimapCircle : MonoBehaviour
{
    private Camera m_Cam;
    private SpriteRenderer m_Renderer;

    public Color m_InColor = Color.red;
    public Color m_OutColor = Color.yellow;

    private void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        m_Cam = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        transform.position = transform.parent.transform.position;
        transform.position += Vector3.up * 5.0f;

        Vector3 position = m_Cam.transform.localPosition;
        position.y = transform.position.y;

        float distance = Vector3.Distance(transform.position, position);
        float size = m_Cam.orthographicSize * 0.95f;
        if (distance >= size)
        {
            Vector3 from = transform.position - position;
            from *= size / distance;

            transform.position = position + from;
            m_Renderer.color = m_OutColor;
        }
        else
        {
            m_Renderer.color = m_InColor;
        }
    }

}
