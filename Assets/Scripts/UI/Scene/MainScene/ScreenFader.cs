using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MaskableGraphic))]
public class ScreenFader : MonoBehaviour
{
    private MaskableGraphic[] images;

    private void Awake()
    {
        images = GetComponentsInChildren<MaskableGraphic>();
    }

    private void Start()
    {
        float fadeOffTime = 3f;
        foreach (MaskableGraphic image in images)
        {
            image?.CrossFadeAlpha(0f, fadeOffTime, true);
            StartCoroutine(DisableRoutine(image, fadeOffTime));
        }
    }

    IEnumerator DisableRoutine(MaskableGraphic graphic, float disableTime)
    {
        while (graphic.color.a > 0)
        {
            yield return null;
        }
        graphic?.gameObject.SetActive(false);
    }
}
