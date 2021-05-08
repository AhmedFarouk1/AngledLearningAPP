using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObjectUI : MonoBehaviour
{
    public string objectText;
    public Vector3 originalPosition;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnRelease()
    {
        rectTransform.anchoredPosition = originalPosition;

    }
}
