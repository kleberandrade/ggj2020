using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("UI")]
    public Image m_Bar;
    public Text m_Label;

    [Header("Settings")]
    public float m_MaxValue;

    [Header("Time")]
    public bool m_UseTime;
    public float m_FillTime;

    private float m_Value;
    private float m_ElapsedTime;

    private void Start()
    {
        UpdateHealth(m_MaxValue);
    }

    public void SetIncrementalValue(float value) {
        if (m_UseTime){
            StartCoroutine(UpdateHealthTime(m_Value, Mathf.Clamp(m_Value + value, 0.0f, m_MaxValue)));
        } else {
            UpdateHealth(value);
        }
    }

    private void UpdateHealth(float value)
    {
        m_Value = Mathf.Clamp(m_Value + value, 0.0f, m_MaxValue);
        m_Bar.fillAmount = m_Value / m_MaxValue;

        if (m_Label)
            m_Label.text = string.Format("{0:0} / {1:0}", m_Value, m_MaxValue);
    }

    private IEnumerator UpdateHealthTime(float fromValue, float toValue)
    {
        m_ElapsedTime = 0.0f;
        while(m_ElapsedTime / m_FillTime < 1.0f)
        {
            m_ElapsedTime += Time.deltaTime;
            m_Value = Mathf.Lerp(fromValue, toValue, m_ElapsedTime / m_FillTime);
            m_Bar.fillAmount = m_Value / m_MaxValue;
            m_Label.text = string.Format("{0:0} / {1:0}", m_Value, m_MaxValue);
            yield return null;
        }
    }
}
