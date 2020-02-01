using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelected : MonoBehaviour
{
    public EventSystem m_EventSystem;
    public GameObject m_SelectedObject;

    private void OnEnable()
    {
        SelectFirstObject();
    }

    private void SelectFirstObject()
    {
        if (m_EventSystem && m_SelectedObject)
        {
            m_EventSystem.SetSelectedGameObject(null);
            m_EventSystem.SetSelectedGameObject(m_SelectedObject);
            Canvas.ForceUpdateCanvases();
        }
    }
}
