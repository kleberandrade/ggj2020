using UnityEngine;

public class SyncGamepad : MonoBehaviour
{
    public int m_RequiredPlayerNumber = 4;
    public GameObject[] m_ActivatedPlayerSlot;
    public GameObject m_FinalText;

    public bool[] m_ActivatedPlayers;
    private bool m_ActivatedAllPlayers;

    public string m_NextScene = "Gameplay";
    private ChangeScene m_ChangeScece;

    private void Start()
    {
        m_ChangeScece = GetComponent<ChangeScene>();
        m_ActivatedPlayers = new bool[m_RequiredPlayerNumber];
    }

    private void Update()
    {
        for (int i = 0; i < m_RequiredPlayerNumber; i++)
        {
            if (GetButtonToActivitade(i + 1))
            {
                m_ActivatedPlayers[i] = true;
                m_ActivatedPlayerSlot[i].SetActive(true);
            }
        }

        if (VerifyIfAllJoysticks())
        {
            if (Input.GetButtonDown("XboxOneButtonA1") || Input.GetButtonDown("XboxOneButtonA2") || Input.GetButtonDown("XboxOneButtonA3") || Input.GetButtonDown("XboxOneButtonA4"))
                m_ChangeScece.LoadLevelWithLoading(m_NextScene);
        }
    }

    public bool GetButtonToActivitade(int id)
    {
        return Input.GetButtonDown($"XboxOneButtonY{id}");
    }

    public bool VerifyIfAllJoysticks() 
    {
        for (int i = 0; i < m_RequiredPlayerNumber; i++)
        {
            if (!m_ActivatedPlayers[i])
                return false;
        }

        m_FinalText.SetActive(true);
        return true;
    }
}
