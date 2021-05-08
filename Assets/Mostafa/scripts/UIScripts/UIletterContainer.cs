using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIletterContainer : MonoBehaviour, IDropHandler
{
    public string letter;//the letter that we will compare against

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggableObject draggableObject = collision.gameObject.GetComponent<DraggableObject>();

        if (draggableObject.objectName == letter)
        {
            draggableObject.originalPosition = transform.position;
        }
    }

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
