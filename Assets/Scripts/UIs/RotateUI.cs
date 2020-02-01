using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    public float m_Speed = 180.0f;
    public Vector3 m_RotateAxis = Vector3.forward;

    private void Update()
    {
        transform.Rotate(m_RotateAxis * m_Speed * Time.deltaTime);
    }
}
