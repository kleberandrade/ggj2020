using UnityEngine;

public class Spawn : MonoBehaviour
{
    public string m_SpawnCommand = "XboxOneButtonA";
    public GameObject SpawnPoint;
    public GameObject Drone;
    public CameraFollow m_Camera;
    private bool Cooldown = false;

    private void Start()
    {
        m_Camera = GetComponentInChildren<CameraFollow>();
    }

    void Update()
    {
        if (Input.GetButtonDown(m_SpawnCommand) && !Cooldown)
        {
            Cooldown = true;
            var AUX = Instantiate<GameObject>(Drone, SpawnPoint.transform.position + new Vector3(0.0f, 2.0f, 0.0f), SpawnPoint.transform.rotation);
            AUX.GetComponent<Controller>().SpawnScript = this; 
            AUX.GetComponent<Controller>().Camera = m_Camera; 
            AUX.GetComponent<Controller>().SpawnTransform = transform; 
            m_Camera.m_Target = AUX.transform;
        }
    }

    public void CoolDownToSpawn()
    {
        Cooldown = false;
    }
}
