using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EndingSceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector goodEndingDirector;
    [SerializeField] private PlayableDirector badEndingDirector;

    [SerializeField] private Volume volume;
    private DepthOfField _depthOfField;
    private SoundManager _soundManager;

    private bool _isGoodEnding;

    private void Awake()
    {
        _soundManager = SoundManager.Instance;
    }

    private void Start()
    {
        goodEndingDirector.stopped += OnTimelineFinished;
        badEndingDirector.stopped += OnTimelineFinished;

        _isGoodEnding = GameManager.Instance.IsGoodEnding;

        _soundManager.Stop();
        if (_isGoodEnding)
        {
            goodEndingDirector.gameObject.SetActive(true);
            _soundManager.Play("Ending/GoodEndingBGM");
        }
        else
        {
            badEndingDirector.gameObject.SetActive(true);
            _soundManager.Play("Ending/BadEndingBGM");
        }
    }

    private void OnTimelineFinished(PlayableDirector director)
    {
        Time.timeScale = 0;
    }

    public void SetGoodEndingCameraFocus()
    {
        volume.profile.TryGet(out _depthOfField);
        if (_depthOfField == null) return;
        _depthOfField.focusDistance.value = 5.0f;
    }
}
