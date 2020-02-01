using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Drone;
    private bool Cooldown = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !Cooldown)
        {
            Cooldown = true;
            var AUX = Instantiate<GameObject>(Drone, SpawnPoint.transform.position + new Vector3(0.0f, 2.0f, 0.0f), SpawnPoint.transform.rotation);
            AUX.GetComponent<Controller>().SpawnScript = this; 
        }
    }

    // Update is called once per frame
    public void CoolDownToSpawn()
    {
        Cooldown = false;
    }
}
