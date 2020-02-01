using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScene : MonoBehaviour
{
    public void LoadLevel(string sceneName)
    {
        ScreenManager.Instance.LoadLevel(sceneName);
    }

    public void LoadLevelWithLoading(string sceneName)
    {
        ScreenManager.Instance.LoadLevelLoading(sceneName);
    }
}
