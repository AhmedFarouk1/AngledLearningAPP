using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPlate : MonoBehaviour, IDropHandler
{
    public RectTransform[] fruitPositions;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on droppp");
        if (eventData.pointerDrag != null)
        {
            if (currentIndex < fruitPositions.Length)
            {
                DraggableObjectUI dragableObjectUI = eventData.pointerDrag.GetComponent<DraggableObjectUI>();
                dragableObjectUI.originalPosition = fruitPositions[currentIndex].anchoredPosition;
                currentIndex++;
            }
        }
    }
}
