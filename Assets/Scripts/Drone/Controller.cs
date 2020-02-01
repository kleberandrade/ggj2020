using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    public Drop DropScript;
    public Pick PickScript;
    public Spawn SpawnScript;
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
    }

    void RemoveCooldown(){
        SpawnScript.CoolDownToSpawn();
        Destroy(this);
    }
}
