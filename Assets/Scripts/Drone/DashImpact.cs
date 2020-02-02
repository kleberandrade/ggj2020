using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashImpact : MonoBehaviour
{
    //public Drop Controller;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            other.GetComponent<Controller>().Death(true);
        }
    }
}
