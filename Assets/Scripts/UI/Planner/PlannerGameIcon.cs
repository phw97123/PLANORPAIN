using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlannerGameIcon : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image GameIcon;
    public GameScene GameScene;
    public Vector3 StartPosition;
    public bool setSlot;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    public void GoStartPosition()
    {
        _rectTransform.anchoredPosition = StartPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (setSlot) return;
        _rectTransform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / _canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        if(!setSlot) { GoStartPosition(); }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
