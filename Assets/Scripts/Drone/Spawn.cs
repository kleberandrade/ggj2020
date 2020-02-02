using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Spawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Drone;
    public CinemachineVirtualCamera Cinemachine;
    private bool Cooldown = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !Cooldown)
        {
            Cooldown = true;
<<<<<<< Updated upstream
=======
            GameManager.Instance.m_EnergyBars[m_Id - 1].Play();
            GameManager.Instance.m_SpawnButton[m_Id-1].DisableUI();

>>>>>>> Stashed changes
            var AUX = Instantiate<GameObject>(Drone, SpawnPoint.transform.position + new Vector3(0.0f, 2.0f, 0.0f), SpawnPoint.transform.rotation);
            AUX.GetComponent<Controller>().SpawnScript = this; 
            AUX.GetComponent<Controller>().Cinemachine = Cinemachine; 
            AUX.GetComponent<Controller>().SpawnTransform = transform; 
            Cinemachine.Follow = AUX.transform;
            Cinemachine.LookAt = AUX.transform;
        }
    }

    // Update is called once per frame
    public void CoolDownToSpawn()
    {
        Cooldown = false;
        GameManager.Instance.m_SpawnButton[m_Id-1].EnableUI();
    }
}
