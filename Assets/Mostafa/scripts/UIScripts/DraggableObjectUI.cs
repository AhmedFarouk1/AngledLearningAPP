using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DraggableObjectUI : MonoBehaviour
{
    public string objectText;
    public Vector3 originalPosition;
    public Vector3 originalScale;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.position;
        originalScale = rectTransform.localScale;
    }

    public void OnRelease()
    {
        rectTransform.position = originalPosition;
        rectTransform.localScale = originalScale;
    }

    public void GoToOriginalPos()
    {
        GetComponent<RectTransform>().DOMove(originalPosition, 0.5f);
    }
}
