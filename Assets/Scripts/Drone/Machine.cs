using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public int Level = 0;

    public int Itens = 0;
    public int NumPlayer = 0;
    // Update is called once per frame
    public void UpdateItens(int ItensADD)
    {
        Itens += ItensADD;
        if(Itens >= 3){
            Itens = Itens - 3;
            Level++;
        }
    }

    public int FurtarItens()
    {
        return Itens;
    }
}
