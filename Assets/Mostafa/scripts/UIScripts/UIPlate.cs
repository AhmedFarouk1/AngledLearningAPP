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

                    if (Stage2._instance.word == "INSIDE")
                    {
                        SpeechManager._instance.ChangeSpeechBubble(dragableObjectUI.GetComponent<RectTransform>().GetComponent<DraggableObjectUI>().objectText + " is INSIDE the bowl");
                        GeneralAudioManager._instance.audiosource.clip = dragableObjectUI.GetComponent<AudioClips>().inside;//???? :(

                    }
                    else if (Stage2._instance.word == "OUTSIDE")
                    {
                        SpeechManager._instance.ChangeSpeechBubble(dragableObjectUI.GetComponent<RectTransform>().GetComponent<DraggableObjectUI>().objectText + " is OUTSIDE the bowl");
                        GeneralAudioManager._instance.audiosource.clip = dragableObjectUI.GetComponent<AudioClips>().outside;//???? :(
                    }
                    GeneralAudioManager._instance.audiosource.Play();

                    Stage2._instance.FruitDraggedToPlateCallback();
                    dragableObjectUI.originalPosition = fruitPositions[currentIndex].position;
                    dragableObjectUI.GetComponent<Image>().raycastTarget = false;
                    currentIndex++;
                }
            }
        }
    }
}
    