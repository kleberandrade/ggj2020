using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject Spot1;
    public GameObject Spot2;
    public GameObject Spot3;
    private int Level = 0;
    public int Itens = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Itens > 3){
            Level++;
            Itens = Itens - 3;
        }
    }
}
