using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public Rigidbody m_rb;

    [Header("Player Controller")]
	public string m_HorizontalAxisName = "Horizontal";
	public string m_VerticalAxisName = "Vertical";

    public string m_DashAxisName = "Dash";

    [Header("DroneStatus")]
	public float m_Speed = 15.0f;
    public float m_MultiplyDash = 2.0f;
    private float m_HorizontalInput;
	private float m_VerticalInput;
    private Vector3 m_Movement;
<<<<<<< Updated upstream
=======
    private Vector3 m_StartDirection;
    public LayerMask m_LayerMask;
    public float m_Distance = 0.5f;
    public GameObject m_DashTrigger;
    private bool CanDash = true;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
            Quaternion angle = Quaternion.LookRotation(m_Movement);
            m_rb.MoveRotation(angle);
        }

        m_rb.MovePosition(m_rb.position + m_Movement.normalized * m_Speed * Time.fixedDeltaTime);
=======
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, m_Distance, m_LayerMask))
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
             else 
                transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
        }

        if(Input.GetAxisRaw(m_DashAxisName) != 0 && CanDash){
            CanDash = false;
            m_DashTrigger.SetActive(true);
            m_Distance = 2.0f;
            m_Speed = m_Speed * m_MultiplyDash;
            Invoke("ResetSpeed", 0.3f);
        }
    }

    void ResetSpeed(){
        m_DashTrigger.SetActive(false);
        m_Speed = m_Speed / m_MultiplyDash;
        m_Distance = 0.5f;
>>>>>>> Stashed changes
    }
}
