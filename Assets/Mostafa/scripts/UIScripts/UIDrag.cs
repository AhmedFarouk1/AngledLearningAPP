using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    public Canvas canvas;
    public UnityEvent onRelease;

    public float scaleFactor;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalScale;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        originalScale = rectTransform.localScale;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        Debug.Log("on begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (onRelease != null) onRelease.Invoke();
        Debug.Log("on end drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.localScale *= scaleFactor;
        Debug.Log("on pointer down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rectTransform.localScale = originalScale;
    }
}
