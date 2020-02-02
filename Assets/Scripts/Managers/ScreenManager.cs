using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : Singleton<ScreenManager>
{
    [Header("Transition")]
    public Animator m_FaderAnimator;

    [Header("Loading")]
    public GameObject m_LoadingPanel;

    public float m_DelayAfterLaoding = 2.0f;

    public void LoadLevel(string nextSceneName)
    {
        StartCoroutine(ChangeScene(nextSceneName, false));
    }

    public void LoadLevelLoading(string nextSceneName)
    {
        StartCoroutine(ChangeScene(nextSceneName, true));
    }

    public IEnumerator ChangeScene(string nextSceneName, bool loading)
    {
        m_FaderAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(m_FaderAnimator.GetCurrentAnimatorStateInfo(0).length);

        if (nextSceneName.Equals("Quit"))
        {
            //Helpers.Quit();
        }
        else
        {
            if (loading)
            {
                m_LoadingPanel.SetActive(true);

                m_FaderAnimator.SetTrigger("Open");
                yield return new WaitForSeconds(m_FaderAnimator.GetCurrentAnimatorStateInfo(0).length);
            }

            AsyncOperation asyncScene = SceneManager.LoadSceneAsync(nextSceneName);

            asyncScene.allowSceneActivation = false;

            while (!asyncScene.isDone)
            {
                if (asyncScene.progress >= 0.9f)
                {
                    if (loading)
                    {
                        yield return new WaitForSeconds(m_DelayAfterLaoding);

                        m_FaderAnimator.SetTrigger("Close");
                        yield return new WaitForSeconds(m_FaderAnimator.GetCurrentAnimatorStateInfo(0).length);

                        m_LoadingPanel.SetActive(false);
                    }

                    asyncScene.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}