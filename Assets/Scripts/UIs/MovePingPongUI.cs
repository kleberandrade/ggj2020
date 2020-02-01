using UnityEngine;

public class MovePingPongUI : MonoBehaviour
{
    public float m_Range = 0.05f;
    public float m_SmoothTime = 10.0f;
    public Vector3 m_Axis = Vector3.up;

    private Vector3 m_StartPosition;

    private void Start()
    {
        m_StartPosition = transform.position;
    }

    private void Update()
    {
        transform.position = m_StartPosition + m_Axis * Mathf.Sin(Time.time * m_SmoothTime) * m_Range;
    }
}
