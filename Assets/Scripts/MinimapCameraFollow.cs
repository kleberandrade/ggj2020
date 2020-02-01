using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    public Transform m_Target;
    public float m_Height = 20.0f;

    private void LateUpdate()
    {
        if (!m_Target) return;

        Vector3 position = m_Target.position;
        position.y += m_Height;

        transform.position = position;
    }
}
