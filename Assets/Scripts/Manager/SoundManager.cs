using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum AudioType
{
    BGM,
    EFFECT,
}

public class SoundManager : Singleton<SoundManager>
{
    public Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    private AudioClip LoadAudioClip(string name)
    {
        if (!audioClips.ContainsKey(name))
        {
            var obj = Instantiate(Resources.Load($"Prefabs/Sprites/{name}"));
            audioClips.Add(name, obj.GetComponent<AudioClip>());
        }
        return audioClips[name];
    }

    public void Play(string audioClipName, AudioType audioType = AudioType.BGM, float pitch = 1.0f)
    {
        AudioClip audioClip = LoadAudioClip(audioClipName);
        
        switch(audioType)
        {
            case AudioType.BGM:
                if (_audioSource.isPlaying) _audioSource.Stop();
                _audioSource.pitch = pitch;
                _audioSource.clip = audioClip;
                _audioSource.Play();
                break;
            case AudioType.EFFECT:
                _audioSource.pitch = pitch;
                _audioSource.PlayOneShot(audioClip);
                break;
        }
    }
}
