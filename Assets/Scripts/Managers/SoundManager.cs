using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Range(0.0f, 10.0f)]
    public float transitionTime = 1.0f;
    [Range(0.0f, 1.0f)]
    public float bgmVolume = 1.0f;
    public string musicPath = "Audios/Music/";
    public bool useCameraPosition = true;
    private float[] finalVolumes = { 0.0f, 1.0f };
    private AudioSource[] sources = new AudioSource[2];
    private int currentSource = 1;

    private void Awake()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
            sources[i].loop = true;
        }
    }

	public void PlayClip(string clipName)
    {
        if (clipName == null)
            return;

        if (clipName == string.Empty)
            return;

        AudioClip clip = Resources.Load<AudioClip>(musicPath + clipName);
        if (clip == null)
            return;

        if (clip == sources[currentSource].clip)
            return;

        finalVolumes[currentSource] = 0.0f;
        SwapCurrent();
        finalVolumes[currentSource] = bgmVolume;

        sources[currentSource].clip = clip;
        sources[currentSource].Play();
    }

	void SwapCurrent()
    {
        currentSource = (++currentSource) % sources.Length;
    }

	void Update()
    {
        if (useCameraPosition && Camera.main != null)
            transform.position = Camera.main.transform.position;

        sources[0].volume = Mathf.Lerp(sources[0].volume, finalVolumes[0], transitionTime * Time.deltaTime);
        sources[1].volume = Mathf.Lerp(sources[1].volume, finalVolumes[1], transitionTime * Time.deltaTime);
    }
}
