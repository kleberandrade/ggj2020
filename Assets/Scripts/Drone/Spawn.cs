using UnityEngine;

public class Spawn : MonoBehaviour
{
    public string m_SpawnCommand = "XboxOneButtonA";
    public GameObject SpawnPoint;
    public GameObject Drone;
    public CameraFollow m_Camera;
    private bool Cooldown = false;
    public int m_Id;

    [Header("SFX")]
    public AudioClip m_SpawnAudioClip;

    private void Start()
    {
        m_Camera = GetComponentInChildren<CameraFollow>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(m_SpawnCommand) && !Cooldown)
        {
            AudioSource.PlayClipAtPoint(m_SpawnAudioClip, transform.position, 1.0f);

            Cooldown = true;
            GameManager.Instance.m_EnergyBars[m_Id - 1].Play();
            GameManager.Instance.m_SpawnButton[m_Id-1].DisableUI();

            var drone = Instantiate<GameObject>(Drone, SpawnPoint.transform.position + new Vector3(0.0f, 2.0f, 0.0f), SpawnPoint.transform.rotation);
            drone.GetComponent<Controller>().SpawnScript = this; 
            drone.GetComponent<Controller>().Camera = m_Camera; 
            drone.GetComponent<Controller>().SpawnTransform = transform; 
            m_Camera.m_Target = drone.transform;
        }
    }

    public void CoolDownToSpawn()
    {
        Cooldown = false;
        GameManager.Instance.m_SpawnButton[m_Id-1].EnableUI();
    }
}
