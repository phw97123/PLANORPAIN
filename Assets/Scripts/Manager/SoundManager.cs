using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    BGM,
    EFFECT,
}

public class SoundManager : Singleton<SoundManager>
{
    // Resources/Sounds 폴더 안의 사운드 소스들을 저장하는 딕셔너리
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
            // 요청 시점에 사운드 클립이 없다면 Load
            AudioClip audioClip = Resources.Load<AudioClip>($"Sounds/{name}");
            audioClips.Add(name, audioClip);
        }
        return audioClips[name];
    }

    // 배경 음악 또는 효과음 재생
    // 배경 음악 재생 : SoundManager.Instance.Play("오디오 클립 이름", AudioType.BGM);
    // 효과음 재생 : SoundManager.Instance.Play("오디오 클립 이름");
    // volume 조절 필요할 시 volume 값도 전달
    public void Play(string audioClipName, AudioType audioType = AudioType.EFFECT, float volume = 1.0f)
    {
        AudioClip audioClip = LoadAudioClip(audioClipName);
        
        switch(audioType)
        {
            case AudioType.BGM:
                if (_audioSource.isPlaying) _audioSource.Stop();
                _audioSource.volume = volume;
                _audioSource.clip = audioClip;
                _audioSource.loop = true;
                _audioSource.Play();
                break;
            case AudioType.EFFECT:
                _audioSource.volume = volume;
                _audioSource.PlayOneShot(audioClip);
                break;
        }
    }
}
