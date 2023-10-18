using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EndingSceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector goodEndingDirector;
    //[SerializeField] private PlayableDirector badEndingDirector;

    [SerializeField] private Volume volume;
    private DepthOfField _depthOfField;

    private bool _isGoodEnding;

    private void Awake()
    {
        volume.profile.TryGet(out _depthOfField);
    }

    private void Start()
    {
        goodEndingDirector.stopped += OnTimelineFinished;
        //badEndingDirector.stopped += OnTimelineFinished;
        if (!_isGoodEnding) goodEndingDirector.gameObject.SetActive(false);
        //else badEndingDirector.gameObject.SetActive(false);
    }

    private void OnTimelineFinished(PlayableDirector director)
    {
        Time.timeScale = 0;
    }

    public void SetGoodEndingCameraFocus()
    {
        if (_depthOfField == null) return;
        _depthOfField.focusDistance.value = 5.0f;
    }
}
