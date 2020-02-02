using UnityEngine;

public class StartPlayMusic : MonoBehaviour
{
    public AudioClip m_Music;

    private void Start()
    {
        SoundManager.Instance.PlayClip(m_Music);
    }
}
