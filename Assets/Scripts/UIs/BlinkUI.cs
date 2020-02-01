using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class BlinkUI : MonoBehaviour
{
    public float m_SmoothTime = 1.0f;
    private CanvasGroup m_CanvasGroup;

    private void Awake()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        m_CanvasGroup.alpha = (Mathf.Sin(Time.time * m_SmoothTime) + 1.0f) * 0.5f;
    }
}
