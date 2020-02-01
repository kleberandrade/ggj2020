using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInOut : MonoBehaviour
{
    public enum TransitionType { In, None, Out }
    private TransitionType m_Type = TransitionType.None;

    public float m_Time = 0.5f;
    public bool m_PlayOnAwake;

    private float m_ElapsedTime;
    private CanvasGroup m_CanvasGroup;

    private void Awake()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        m_Type = TransitionType.None;
        if (m_PlayOnAwake)
            Show();
    }

    public void Show()
    {
        if (m_Type != TransitionType.None)
            return;

        m_CanvasGroup.alpha = 0.0f;
        m_Type = TransitionType.In;
        m_ElapsedTime = 0.0f;
    }

    public void Hide()
    {
        if (m_Type != TransitionType.None)
            return;

        m_CanvasGroup.alpha = 1.0f;
        m_Type = TransitionType.Out;
        m_ElapsedTime = 0.0f;
    }

    private void Update()
    {
        if (m_Type == TransitionType.In)
        {
            m_CanvasGroup.alpha = Mathf.Lerp(0.0f, 1.0f, m_ElapsedTime / m_Time);
            if (m_ElapsedTime / m_Time >= 1.0f)
            {
                m_Type = TransitionType.None;
            }
        }

        if (m_Type == TransitionType.Out)
        {
            m_CanvasGroup.alpha = Mathf.Lerp(1.0f, 0.0f, m_ElapsedTime / m_Time);

            if (m_ElapsedTime / m_Time >= 1.0f)
            {
                m_Type = TransitionType.None;
                gameObject.SetActive(false);
            }
        }

        m_ElapsedTime += Time.deltaTime;
    }
}
