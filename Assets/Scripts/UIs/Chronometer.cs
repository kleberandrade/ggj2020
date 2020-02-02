using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    public delegate void OnFinishedHandler();
    public static event OnFinishedHandler OnFinished;

    private float m_StartTime = 0.0f;
    private bool m_Stopped = true;
    private float m_ElapsedTime;

    public bool m_UseAutoPlay = true;
    public float m_MaxTime;

    [Header("UI")]
    public Image m_Bar;
    public Text m_Label;

    private void Start()
    {
        if (m_UseAutoPlay)
            Play(m_MaxTime == 0.0f ? 300.0f : m_MaxTime);
    }

    private void Play(float maxTime)
    {
        m_MaxTime = maxTime;
        m_StartTime = Time.time;
        m_Stopped = false;
    }

    private void Update()
    {
        if (m_Stopped)
            return;

        m_ElapsedTime = Time.time - m_StartTime;

        float rate = Mathf.Clamp01(m_ElapsedTime / m_MaxTime);

        m_Bar.fillAmount = rate;
        m_Label.text = $"{Mathf.RoundToInt(m_MaxTime - m_ElapsedTime)}";

        if (rate >= 1.0f)
        {
            m_Stopped = true;

            if (OnFinished != null)
            {
                Debug.Log("[Chronometer] Invoke OnFinish");
                OnFinished();
            }
        }
    }
}
