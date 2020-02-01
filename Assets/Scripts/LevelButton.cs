using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Image m_BkgImage;
    public Image m_LockedImage;
    public Text m_NameText;
    public Image m_ScoreImage;

    private Button m_Button;

    private void Awake()
    {
        m_Button = GetComponent<Button>();
    }

    public void SetNextLevel(string nextLevelName)
    {
        m_Button.onClick.RemoveAllListeners();
        m_Button.onClick.AddListener(delegate {
            ScreenManager.Instance.LoadLevelLoading(nextLevelName);
        });
    }

    public void Lock(bool locked)
    {
        if (m_LockedImage)
        {
            m_LockedImage.enabled = !locked;
        }
    }

    public void SetName(string name)
    {
        if (m_NameText) m_NameText.text = name;
    }

    public void SetBackground(Sprite sprite)
    {
        if (m_BkgImage) m_BkgImage.sprite = sprite;
    }

    public void SetScore(int score, int[] scoreLevels)
    {
        if (m_ScoreImage)
        {
            for (int i = scoreLevels.Length - 1; i >= 0; i--)
            {
                if (score >= scoreLevels[i])
                    m_ScoreImage.fillAmount = (i + 1) / (float)scoreLevels.Length;
            }
        }
    }
}
