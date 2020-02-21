using UnityEngine;

public class Controller : MonoBehaviour
{
    public Drop DropScript;
    public Pick PickScript;
    public Spawn SpawnScript;
    public Transform SpawnTransform;
    public CameraFollow Camera;
    public int Itens = 0;
    public int NumPlayer;

    [Header("SFX")]
    public AudioClip m_ExplosionAudioClip;
    public AudioClip m_TimeoverAudioClip;
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        Invoke("TimeDeath",20);
    }

    public void Death(bool Impact = false)
    {
        if(Impact)
            m_AudioSource.clip = m_ExplosionAudioClip;
        else
            m_AudioSource.clip = m_TimeoverAudioClip;

        m_AudioSource.Play();

        GameManager.Instance.m_EnergyBars[NumPlayer - 1].Stop();

        Invoke("RemoveCooldown",2);
        Destroy(PickScript);
        Destroy(transform.GetChild(3).gameObject);

        DropScript.DropDeath();
        Camera.m_Target = SpawnTransform;
    }

    void RemoveCooldown()
    {
        SpawnScript.CoolDownToSpawn();
        Destroy(this);
    }

    void TimeDeath()
    {
        Death(false);
    }
}
