using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public enum HealthBarState { None, Increase, Decrease }

    [Header("UI")]
    public Image m_Bar;

    [Header("Settings")]
    public float m_LifeTime;
    public float m_CooldownTime;

    private float m_StartTime;
    private HealthBarState m_State = HealthBarState.None;

    public void Play()
    {
        m_StartTime = Time.time;
        m_State = HealthBarState.Increase;
    }

    public void Stop()
    {
        m_StartTime = Time.time;
        m_State = HealthBarState.Decrease;
    }

    public void Update()
    {
        if (m_State == HealthBarState.Increase)
        {
            float value = (Time.time - m_StartTime) / m_LifeTime;
            m_Bar.fillAmount = 1.0f - value;

            if (value >= 1.0f)
                Stop();
        }

        if (m_State == HealthBarState.Decrease)
        {
            float value = (Time.time - m_StartTime) / m_CooldownTime;
            m_Bar.fillAmount = value;

            if (value >= 1.0f)
            {
                m_State = HealthBarState.None;
            }
        }
    }
}
