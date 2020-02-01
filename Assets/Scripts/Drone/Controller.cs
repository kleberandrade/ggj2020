using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Controller : MonoBehaviour
{
    
    public Drop DropScript;
    public Pick PickScript;
    public Spawn SpawnScript;
    public Transform SpawnTransform;
    public CinemachineVirtualCamera Cinemachine;
    public int Itens = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death",20);
    }

    // Update is called once per frame
    void Death()
    {
        Invoke("RemoveCooldown",2);
        Destroy(PickScript);
        DropScript.DropDeath();
        Cinemachine.Follow = SpawnTransform;
        Cinemachine.LookAt = SpawnTransform;
    }

    void RemoveCooldown(){
        SpawnScript.CoolDownToSpawn();
        Destroy(this);
    }
}
