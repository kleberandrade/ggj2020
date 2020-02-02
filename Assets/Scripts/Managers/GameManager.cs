using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("HUD")]
    public HealthBar[] m_EnergyBars;
    public GearsBar[] m_GearsBars;
    public Chronometer m_Chronometer;

    [Header("Setup")]
    public float m_MaxTime = 300.0f;

    private void OnEnable()
    {
        Chronometer.OnFinished += OnFinished;
    }

    private void OnDisable()
    {
        Chronometer.OnFinished -= OnFinished;
    }

    private void OnFinished()
    {
        CreateRanking();

    }

    private void CreateRanking()
    {
        Ranking ranking = new Ranking();
        for (int i = 0; i < m_GearsBars.Length; i++)
            ranking.Users.Add(new User() { Id = i + 1, Gears = m_GearsBars[i].Amount });
    }
}

public class Ranking
{
    public List<User> Users { get; set; }
}

public class User
{
    public int Id { get; set; }
    public int Gears { get; set; }
}
