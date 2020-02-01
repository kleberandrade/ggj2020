using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    public Controller ControllerScript;
    public Machine MachineScript;
    public Machine EnemyMachineScript;
    public string Nome_Tag;
    public string Place_Tag;
    void Start()
    {
        GameObject[] AUX_Machine;
        AUX_Machine = GameObject.FindGameObjectsWithTag(Nome_Tag);
        MachineScript = AUX_Machine[0].GetComponent<Machine>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item")){
            
            if(ControllerScript.Itens < 3){
                Item.m_Count--;
                Destroy(other.gameObject);
                ControllerScript.Itens++;
            }
        }else if(other.CompareTag(Nome_Tag)){
            if(ControllerScript.Itens > 0){
                MachineScript.UpdateItens(ControllerScript.Itens);
                ControllerScript.Itens = 0;
            }
        }else{
            if(ControllerScript.Itens < 3){
                EnemyMachineScript = other.GetComponent<Machine>();
                ControllerScript.Itens += EnemyMachineScript.FurtarItens();
                EnemyMachineScript.Itens = 0;
                if(ControllerScript.Itens > 3){
                    EnemyMachineScript.UpdateItens(ControllerScript.Itens -3);
                    ControllerScript.Itens -= ControllerScript.Itens -3;
                }
            }
        }
    }
}
