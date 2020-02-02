using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("HUD")]
    public HealthBar[] m_EnergyBars;
    public GearsBar[] m_GearsBars;
    public Chronometer m_Chronometer;

    [Header("Setup")]
    public float m_MaxTime = 300.0f;

}
