using System.Collections;
using UnityEngine;

public class MapCreator : Singleton<MapCreator>
{
    [Header("Dimension")]
    public int m_Width = 5;
    public int m_Depth = 5;

    [Header("Room")]
    public GameObject[] m_Rooms;
    public int m_Size = 6;

    [Header("Player")]
    public GameObject[] m_Players;

    [HideInInspector]
    public bool m_Left;

    [HideInInspector]
    public bool m_Top;

    [HideInInspector]
    public bool m_Right;

    [HideInInspector]
    public bool m_Bottom;

    [HideInInspector]
    public bool m_Spanwer;

    private void Start()
    {
        StartCoroutine(CreateMap());
    }

    private IEnumerator CreateMap()
    {
        float halfWidth = (m_Width * m_Size - m_Size) * 0.5f;
        float halfDepth = (m_Depth * m_Size - m_Size) * 0.5f;

        for (int x = 0; x < m_Width; x++)
        {
            for (int z = 0; z < m_Depth; z++)
            {
                m_Left = x == 0;
                m_Bottom = z == 0;
                m_Right = x == m_Width - 1;
                m_Top = z == m_Depth - 1;

                Vector3 position = Vector3.zero;
                position.x = -halfWidth + x * m_Size;
                position.z = -halfDepth + z * m_Size;

                m_Spanwer = (m_Left && position.z == 0) || (m_Right && position.z == 0) || (m_Bottom && position.x == 0) || (m_Top && position.x == 0);

                CreateRoom(position);
                CreatePlayer(position);

                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void CreateRoom(Vector3 position)
    {
        int index = Random.Range(0, m_Rooms.Length);

        GameObject tile = Instantiate(m_Rooms[index]);
        tile.transform.position = position;
        tile.transform.parent = transform;
    }

    private void CreatePlayer(Vector3 position)
    {
        if (m_Left && position.z == 0)
        {
            Instantiate(m_Players[0], position + Vector3.up * 1.0f, Quaternion.Euler(0.0f, 90.0f, 0.0f));
        }

        if (m_Right && position.z == 0)
        {
            Instantiate(m_Players[1], position + Vector3.up * 1.0f, Quaternion.Euler(0.0f, 270.0f, 0.0f));
        }

        if (m_Bottom && position.x == 0)
        {
            Instantiate(m_Players[2], position + Vector3.up * 1.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }

        if (m_Top && position.x == 0)
        {
            Instantiate(m_Players[3], position + Vector3.up * 1.0f, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
    }
}