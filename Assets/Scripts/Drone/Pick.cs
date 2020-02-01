using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    public Controller ControllerScript;
    public Machine MachineScript;
    public string Nome_Tag;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item")){
            Destroy(other.gameObject);
            ControllerScript.Itens++;
        }

        if(other.CompareTag(Nome_Tag)){
            MachineScript.Itens += ControllerScript.Itens;
            ControllerScript.Itens = 0;
        }
    }
}
