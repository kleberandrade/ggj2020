using UnityEngine;

public class RoomCreator : MonoBehaviour
{
    [Header("Dimension")]
    public int m_Width = 5;
    public int m_Depth = 5;
    public float m_Size = 4.0f;

    [Header("Tiles")]
    public GameObject[] m_Corners;
    public GameObject[] m_Walls;
    public GameObject[] m_Grounds;

    [Header("Path")]
    public GameObject[] m_Doors;
    public GameObject[] m_Halls;
    public float m_DoorRate = 0.5f;

    private void Start()
    {
        CreateRoom();
    }

    private void CreateRoom()
    {
        float halfWidth = (m_Width * m_Size - m_Size) * 0.5f;
        float halfDepth = (m_Depth * m_Size - m_Size) * 0.5f;

        for (int x = 0; x < m_Width; x++)
        {
            for (int z = 0; z < m_Depth; z++)
            {
                Vector3 position = Vector3.zero;
                position.x = -halfWidth + x * m_Size;
                position.z = -halfDepth + z * m_Size;

                position += transform.position;

                if (!CreateCorner(x, z, position))
                {
                    CreateWall(x, z, position);
                    CreateGround(x, z, position);
                }
            }
        }
    }

    private GameObject GetRandomTile(GameObject[] tiles, Vector3 position)
    {
        int index = Random.Range(0, tiles.Length);

        GameObject tile = Instantiate(tiles[index]);
        tile.transform.position = position;
        tile.transform.parent = transform;

        return tile;
    }

    private void CreateGround(int x, int z, Vector3 position)
    {
        if (x == 0 || z == 0 || x == m_Width - 1 || z == m_Depth - 1)
            return;

        GameObject tile = GetRandomTile(m_Grounds, position);
        tile.transform.rotation = Quaternion.identity;
    }

    private bool CreateCorner(int x, int z, Vector3 position)
    {
        if (x == 0 && z == 0)
        {
            GameObject tile = GetRandomTile(m_Corners, position);
            tile.transform.rotation = Quaternion.Euler(Vector3.up * 270.0f);
            return true;
        }

        if (x == 0 && z == m_Depth - 1)
        {
            GameObject tile = GetRandomTile(m_Corners, position);
            tile.transform.rotation = Quaternion.Euler(Vector3.up * 0.0f);
            return true;
        }

        if (x == m_Width - 1 && z == 0)
        {
            GameObject tile = GetRandomTile(m_Corners, position);
            tile.transform.rotation = Quaternion.Euler(Vector3.up * 180.0f);
            return true;
        }

        if (x == m_Width - 1 && z == m_Depth - 1)
        {
            GameObject tile = GetRandomTile(m_Corners, position);
            tile.transform.rotation = Quaternion.Euler(Vector3.up * 90.0f);
            return true;
        }

        return false;
    }

    private void CreateWall(int x, int z, Vector3 position)
    {
        GameObject tile;
        GameObject hall;

        if (x == 0)
        {
            if (z == m_Depth / 2 && Random.Range(0.0f, 1.0f) < m_DoorRate && !MapBuilder.Instance.m_Left)
            {
                tile = GetRandomTile(m_Doors, position);
                hall = GetRandomTile(m_Halls, position + Vector3.left * m_Size);
            }
            else
            {
                tile = GetRandomTile(m_Walls, position);
            }

            tile.transform.rotation = Quaternion.Euler(Vector3.up * 0.0f);
        }

        if (z == 0)
        {
            if (x == m_Width / 2 && Random.Range(0.0f, 1.0f) < m_DoorRate && !MapBuilder.Instance.m_Bottom)
            {
                tile = GetRandomTile(m_Doors, position);
                hall = GetRandomTile(m_Halls, position + Vector3.back * m_Size);
                hall.transform.rotation = Quaternion.Euler(Vector3.up * 90.0f);
            }
            else
            {
                tile = GetRandomTile(m_Walls, position);
            }

            tile.transform.rotation = Quaternion.Euler(Vector3.up * 270.0f);
        }

        if (x == m_Width - 1)
        {
            if (z == m_Depth / 2 && Random.Range(0.0f, 1.0f) < m_DoorRate && !MapBuilder.Instance.m_Right)
            {
                tile = GetRandomTile(m_Doors, position);
                hall = GetRandomTile(m_Halls, position + Vector3.right * m_Size);
            }
            else
            {
                tile = GetRandomTile(m_Walls, position);
            }

            tile.transform.rotation = Quaternion.Euler(Vector3.up * 180.0f);
        }

        if (z == m_Depth - 1)
        {
            if (x == m_Width / 2 && Random.Range(0.0f, 1.0f) < m_DoorRate && !MapBuilder.Instance.m_Top)
            {
                tile = GetRandomTile(m_Doors, position);
                hall = GetRandomTile(m_Halls, position + Vector3.forward * m_Size);
                hall.transform.rotation = Quaternion.Euler(Vector3.up * 90.0f);
            }
            else
            {
                tile = GetRandomTile(m_Walls, position);
            }

            tile.transform.rotation = Quaternion.Euler(Vector3.up * 90.0f);
        }
    }
}
