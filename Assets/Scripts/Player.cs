using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_Speed = 3.0f;
    public PlayerData m_Data;

    private void Awake()
    {
        m_Data = Persistence.Load<PlayerData>("player.txt");
        if (m_Data == null)
        {
            m_Data = new PlayerData();
            m_Data.lives = 3;
            m_Data.respawnPosition = transform.position;
        }
        else
        {
            transform.position = m_Data.respawnPosition;
        }
    }

    private void Save()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            m_Data.respawnPosition = transform.position;
            Persistence.Save<PlayerData>(m_Data, "player.txt");
        }
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * m_Speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;
        transform.Translate(new Vector3(x, 0.0f, z));
        Save();
    }
}

[Serializable]
public class PlayerData
{
    public Vector3 respawnPosition;
    public int lives;
}