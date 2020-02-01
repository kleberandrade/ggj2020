using UnityEngine;

public class RotateImage : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_RotateAxis = Vector3.forward;

    [SerializeField]
    private float m_RotateSpeed;

    private RectTransform m_Transform;

    public void Awake()
    {
        m_Transform = GetComponent<RectTransform>();
    }

    public void Update()
    {
        m_Transform.Rotate(m_RotateAxis * m_RotateSpeed * Time.deltaTime);
    }
}
