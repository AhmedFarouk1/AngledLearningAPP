using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPlate : MonoBehaviour, IDropHandler
{ 
    public RectTransform[] fruitPositions;
    private int currentIndex = 0;

    public string word;// name of fruit the plate is currently willing to accept, if it recieves a different fruit then the fruit will snap back where it came from

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

                if (dragableObjectUI.objectText == word)
                {
                    Stage2._instance.FruitDraggedToPlateCallback();
                    dragableObjectUI.originalPosition = fruitPositions[currentIndex].position;
                    currentIndex++;
                }
            }
        }
    }
}
    