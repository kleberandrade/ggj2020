using System.Collections;
using UnityEngine;

public class MapBuilder : Singleton<MapBuilder>
{
    [Header("Dimension")]
    public int m_Width = 5;
    public int m_Depth = 5;

    [Header("Room")]
    public GameObject[] m_Rooms;
    public int m_Size = 6;

    [HideInInspector]
    public bool m_Left;

    [HideInInspector]
    public bool m_Top;

    [HideInInspector]
    public bool m_Right;

    [HideInInspector]
    public bool m_Bottom;

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

                CreateRoom(position);

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
}