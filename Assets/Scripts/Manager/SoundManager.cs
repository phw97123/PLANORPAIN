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
    // Resources/Sounds ���� ���� ���� �ҽ����� �����ϴ� ��ųʸ�
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
            // ��û ������ ���� Ŭ���� ���ٸ� Load
            AudioClip audioClip = Resources.Load<AudioClip>($"Sounds/{name}");
            audioClips.Add(name, audioClip);
        }
        return audioClips[name];
    }

    // ��� ���� �Ǵ� ȿ���� ���
    // ��� ���� ��� : SoundManager.Instance.Play("����� Ŭ�� �̸�", AudioType.BGM);
    // ȿ���� ��� : SoundManager.Instance.Play("����� Ŭ�� �̸�");
    // volume ���� �ʿ��� �� volume ���� ����
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
