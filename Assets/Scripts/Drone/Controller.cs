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
    public CameraFollow Camera;
    public int Itens = 0;
    
    void Start()
    {
        Invoke("Death",20);
    }

    void Death()
    {
        Invoke("RemoveCooldown",2);
        Destroy(PickScript);
        DropScript.DropDeath();
        Camera.m_Target = SpawnTransform;
    }

    void RemoveCooldown(){
        SpawnScript.CoolDownToSpawn();
        Destroy(this);
    }
}
