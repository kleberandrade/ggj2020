using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashImpact : MonoBehaviour
{
    public AudioClip m_Explosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            other.GetComponent<Controller>().Death(true);
        }
    }
}
