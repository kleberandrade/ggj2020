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
        Invoke("TimeDeath",20);
    }

    public void Death(bool Impact = false)
    {
        if(Impact){

        }
        Invoke("RemoveCooldown",2);
        Destroy(PickScript);
        DropScript.DropDeath();
        Camera.m_Target = SpawnTransform;
    }

    void RemoveCooldown(){
        SpawnScript.CoolDownToSpawn();
        Destroy(this);
    }

    void TimeDeath(){
        Death(false);
    }
}
