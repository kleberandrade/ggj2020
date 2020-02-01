using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public Rigidbody m_rb;

    [Header("Player Controller")]
	public string m_HorizontalAxisName = "Horizontal";
	public string m_VerticalAxisName = "Vertical";

    [Header("DroneStatus")]
	public float m_Speed = 15.0f;

    private float m_HorizontalInput;
	private float m_VerticalInput;
    private Vector3 m_Movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
		m_HorizontalInput = Input.GetAxisRaw(m_HorizontalAxisName);
		m_VerticalInput = Input.GetAxisRaw(m_VerticalAxisName);
    }

    void FixedUpdate()
    {
        m_Movement = new Vector3(m_HorizontalInput, 0.0f, m_VerticalInput);
    
        if (m_Movement.magnitude != 0.0f)
        {
            Quaternion angle = Quaternion.LookRotation(m_Movement);
            m_rb.MoveRotation(angle);
        }

        m_rb.MovePosition(m_rb.position + m_Movement.normalized * m_Speed * Time.fixedDeltaTime);
    }
}
