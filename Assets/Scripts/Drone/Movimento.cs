using UnityEngine;

public class Movimento : MonoBehaviour
{
    [Header("Player Controller")]
	public string m_HorizontalAxisName = "Horizontal";
	public string m_VerticalAxisName = "Vertical";

    [Header("DroneStatus")]
	public float m_Speed = 15.0f;

    private float m_HorizontalInput;
	private float m_VerticalInput;
    private Vector3 m_Movement;
    private Vector3 m_StartDirection;
    public LayerMask m_LayerMask;
    public float m_Distance = 0.5f;

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
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, m_Distance, m_LayerMask))
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
             else 
                transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
            
        }
    }
}
