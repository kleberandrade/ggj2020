using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public bool m_UseTimeToChangeScene = false;
    public float m_Time = 3.0f;
    public string m_SceneName;

    public void Start()
    {
        if (m_UseTimeToChangeScene)
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
