using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScene : MonoBehaviour
{
    public bool m_UseTimeToChangeScene = false;
    public float m_Time = 3.0f;
    public string m_SceneName;

    public void Start()
    {
        Invoke("LoadLevel", m_Time);
    }

    public void LoadLevelWithTime()
    {
        ScreenManager.Instance.LoadLevel(m_SceneName);
    }

    public void LoadLevel(string sceneName)
    {
        ScreenManager.Instance.LoadLevel(sceneName);
    }

    public void LoadLevelWithLoading(string sceneName)
    {
        ScreenManager.Instance.LoadLevelLoading(sceneName);
    }
}
