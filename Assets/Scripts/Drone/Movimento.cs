using UnityEngine;

public class Movimento : MonoBehaviour
{
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
    private Vector3 m_StartDirection;
    public LayerMask m_LayerMask;
    public float m_Distance = 0.5f;
    public GameObject m_DashTrigger;
    private bool CanDash = true;

    private void Start()
    {
        m_StartDirection = transform.forward;
    }

    private void Update()
    {
		m_HorizontalInput = Input.GetAxisRaw(m_HorizontalAxisName);
		m_VerticalInput = Input.GetAxisRaw(m_VerticalAxisName);

        m_Movement = new Vector3(m_HorizontalInput, 0.0f, m_VerticalInput).normalized;

        if (m_Movement.magnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(m_Movement) * Quaternion.LookRotation(m_StartDirection);    
    }

    private void FixedUpdate()
    {
        if (m_Movement.magnitude > 0.0f)
        {
            Quaternion angle = Quaternion.LookRotation(m_Movement);
            m_rb.MoveRotation(angle);
        }

        m_rb.MovePosition(m_rb.position + m_Movement.normalized * m_Speed * Time.fixedDeltaTime);
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
    }
}
