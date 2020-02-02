using UnityEngine;

public class StartPlayMusic : MonoBehaviour
{
    public string m_musicName;

    private void Start()
    {
        SoundManager.Instance.PlayClip(m_musicName);
    }
}
