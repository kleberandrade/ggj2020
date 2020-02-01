using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    public Drop DropScript;
    public Pick PickScript;
    public int Itens = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death",20);
    }

    // Update is called once per frame
    void Death()
    {
        Destroy(PickScript);
        DropScript.DropDeath();
    }
}
