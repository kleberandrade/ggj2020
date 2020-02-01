using UnityEngine;

public class Item : MonoBehaviour
{
    public static int m_Count = 0;

    [Header("Materials")]
    public Material m_Normal;
    public Material m_Invisible;

    private Renderer m_Renderer;
    private Collider m_Collider;

    private bool m_Visible;
    
    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Collider = GetComponent<Collider>();
    }

    private void Start()
    {
        m_Collider.enabled = false;
        m_Renderer.material = m_Invisible;
        m_Visible = false;
    }

    private void Update()
    {
        if (m_Renderer.isVisible) 
        {
            if (!m_Visible && m_Count < 3)
            {
                Visible();
            }
        }
        else
        {
            if (m_Visible)
            {
                Invisible();
            }
        }
    }

    private void Visible()
    {
        m_Collider.enabled = true;
        m_Renderer.material = m_Normal;
        m_Visible = true;

        m_Count++;
    }

    private void Invisible()
    {
        m_Collider.enabled = false;
        m_Renderer.material = m_Invisible;
        m_Visible = false;

        m_Count--;
    }
}
