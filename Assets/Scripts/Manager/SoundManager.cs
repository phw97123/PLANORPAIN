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
            var obj = Instantiate(Resources.Load($"Sounds/{name}"));
            audioClips.Add(name, obj.GetComponent<AudioClip>());
        }
        return audioClips[name];
    }

    // ��� ���� �Ǵ� ȿ���� ���
    // ��� ���� ��� : SoundManager.Instance.Play("����� Ŭ�� �̸�");
    // ȿ���� ��� : SoundManager.Instance.Play("����� Ŭ�� �̸�", AudioType.EFFECT);
    // pitch ���� �ʿ��� �� pitch ���� ����
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