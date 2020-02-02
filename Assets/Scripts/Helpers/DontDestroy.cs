using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public string m_ObjetName = "SoundManager";

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(m_ObjetName);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}