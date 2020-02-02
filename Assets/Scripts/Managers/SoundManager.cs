using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Range(0.0f, 10.0f)]
    public float m_TransitionTime = 1.0f;
    [Range(0.0f, 1.0f)]
    public float m_BgmVolume = 1.0f;
    public bool m_UseCameraPosition = true;
    private float[] m_FinalVolumes = { 0.0f, 1.0f };
    private AudioSource[] m_Sources = new AudioSource[2];
    private int m_CurrentSource = 1;

    private void Awake()
    {
        for (int i = 0; i < m_Sources.Length; i++)
        {
            m_Sources[i] = gameObject.AddComponent<AudioSource>();
            m_Sources[i].loop = true;
        }
    }

	public void PlayClip(AudioClip clip)
    {
        if (clip == null)
            return;

        if (clip == m_Sources[m_CurrentSource].clip)
            return;

        m_FinalVolumes[m_CurrentSource] = 0.0f;
        SwapCurrent();
        m_FinalVolumes[m_CurrentSource] = m_BgmVolume;

        m_Sources[m_CurrentSource].clip = clip;
        m_Sources[m_CurrentSource].Play();
    }

    private void SwapCurrent()
    {
        m_CurrentSource = (++m_CurrentSource) % m_Sources.Length;
    }

	private void Update()
    {
        if (m_UseCameraPosition && Camera.main != null)
            transform.position = Camera.main.transform.position;

        m_Sources[0].volume = Mathf.Lerp(m_Sources[0].volume, m_FinalVolumes[0], m_TransitionTime * Time.deltaTime);
        m_Sources[1].volume = Mathf.Lerp(m_Sources[1].volume, m_FinalVolumes[1], m_TransitionTime * Time.deltaTime);
    }
}
