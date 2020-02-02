using UnityEngine;
using UnityEngine.UI;

public class GearsBar : MonoBehaviour
{
    public Sprite[] m_Gears;
    public Color[] m_Colors; 

    private Image[] m_Images;

    private int m_PickIndex = 0;
    private int m_PushIndex = 0;

    private void Start()
    {
        m_Images = GetComponentsInChildren<Image>();
        for (int i = 0; i < m_Images.Length; i++)
        {
            m_Images[i].sprite = m_Gears[0];
            m_Images[i].color = m_Colors[0];
        }
    }

    private void Change(int index, int type)
    {
        m_Images[index].sprite = m_Gears[type];
        m_Images[index].color = m_Colors[type];
    } 

    public void Pick()
    {
        Change(m_PickIndex, 1);
        m_PickIndex++;
    }

    public void Drop()
    {
        m_PickIndex--;
        Change(m_PickIndex, 0);
    }

    public void Push()
    {
        Change(m_PushIndex, 2);
        m_PushIndex++;
    }

    public void Pop()
    {
        m_PushIndex--;
        m_PickIndex--;
        Change(m_PushIndex, 0);
    }
}
