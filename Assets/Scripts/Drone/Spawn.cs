﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Drone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate<GameObject>(Drone, SpawnPoint.transform.position + new Vector3(0.0f, 2.0f, 0.0f), SpawnPoint.transform.rotation); 
        }
    }
}
