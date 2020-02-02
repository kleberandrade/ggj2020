using UnityEngine;
using System.Linq;

public class Gameover : MonoBehaviour
{
    public GameObject[] m_Trophys;

    public static Ranking m_Ranking;

    private void Start()
    {
        for (int i = 0; i < m_Trophys.Length; i++)
        {
            m_Trophys[i].SetActive(false);
        }

        Winner();
    }

    public void Winner()
    {
        User user = m_Ranking.Users.OrderByDescending(x => x.Gears).First<User>();
        m_Trophys[user.Id].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("XboxOneButtonA1") || Input.GetButtonDown("XboxOneButtonA2") || Input.GetButtonDown("XboxOneButtonA3") || Input.GetButtonDown("XboxOneButtonA4"))
        {
            ScreenManager.Instance.LoadLevel("MainMenu");
        }
    }
}
