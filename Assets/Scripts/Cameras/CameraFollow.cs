using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform m_Target;

	public float m_SmoothSpeed = 0.125f;
	public Vector3 m_Offset;

	private void FixedUpdate()
	{
		Vector3 desiredPosition = m_Target.position + m_Offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_SmoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(m_Target);
	}
}