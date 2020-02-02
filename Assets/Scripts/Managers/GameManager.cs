using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("HUD")]
    public HealthBar m_EnergyBarP1;
    public HealthBar m_EnergyBarP2;
    public HealthBar m_EnergyBarP3;
    public HealthBar m_EnergyBarP4;
    public GearsBar m_GearsBarP1;
    public GearsBar m_GearsBarP2;
    public GearsBar m_GearsBarP3;
    public GearsBar m_GearsBarP4;
    public Chronometer m_Chronometer;

    [Header("Setup")]
    public float m_MaxTime = 300.0f;

}
