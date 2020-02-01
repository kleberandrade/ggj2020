using UnityEngine;

public class TileCreator : MonoBehaviour
{
    public GameObject[] m_Tiles;

    public Vector3 m_Rotation = Vector3.zero;

    public void Start()
    {
        int index = Random.Range(0, m_Tiles.Length);
        Instantiate(m_Tiles[index], transform.position, Quaternion.Euler(m_Rotation));
    }
}