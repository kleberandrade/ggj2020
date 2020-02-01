using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectManager : MonoBehaviour
{
    public List<Level> m_Levels;
    public GameObject m_LevelButton;
    public Transform m_Contents;

    private void Start()
    {
        FillLevels();
    }

    public void FillLevels()
    {
        foreach (Level level in m_Levels)
        {
            GameObject button = Instantiate(m_LevelButton);
            button.transform.SetParent(m_Contents);
            button.transform.localScale = Vector3.one;

            LevelButton levelButton = button.GetComponent<LevelButton>();
            levelButton.SetName(level.m_Name);
            levelButton.SetBackground(level.m_Sprite);
            levelButton.SetNextLevel(level.m_SceneName);

            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(button);
            }
        }

        Canvas.ForceUpdateCanvases();
    }
}

[Serializable]
public class Level
{
    public string m_Name;
    public string m_SceneName;
    public Sprite m_Sprite;
    public Sprite m_LockedSprite;
    public bool m_Unlocked;
    public int m_BestScore;
    public int[] m_ScoreLevels;
}
