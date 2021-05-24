using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIletterContainer : MonoBehaviour, IDropHandler
{
    public string letter;//the letter that we will compare against

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
        if(eventData.pointerDrag != null)
        {
            DraggableObjectUI dragableObjectUI = eventData.pointerDrag.GetComponent<DraggableObjectUI>();
            if (dragableObjectUI.objectText == letter){  
                dragableObjectUI.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                dragableObjectUI.GetComponent<UIDrag>().enabled = false;//stop dragging the object if it's the correct letter
            }
        }
    }
}
