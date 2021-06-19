using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Stage2 : MonoBehaviour
{

    public RectTransform[] fruitTransforms;

    public RectTransform[] initialFruitTransforms;//go to those positions when button is clicked

    public UIPlate plate;

    public Monkey monkey;

    public Button button_stage_1;
    public Button button_stage_2;
    public Button button_stage_3;

    public float tweenDuration;
     
    private int currentFruitIndex = 0;
    
    bool locked = false; // if true locks actions related to stage 2

    public string[] WordsToBeAssignedToPlate;
    private int WordTobeAssignedIndex = 0;

    public static Stage2 _instance;
    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void OnStage2BtnClick()
    {
        button_stage_2.gameObject.SetActive(false);
        plate.word = WordsToBeAssignedToPlate[WordTobeAssignedIndex];
        MonkeyChair();
        TweenFruitsBackToTable();
        WordTobeAssignedIndex++;

        for(int i = 0; i < fruitTransforms.Length; i++)
        {
            fruitTransforms[i].GetComponent<Image>().raycastTarget = true;
        }
        //make monkey talk
    }

    public void MonkeyChair()
    {
        monkey.doneJumping = false;
        monkey.GotoChair();
    }

    public void TweenFruitsBackToTable()
    {
        for (int i = 0; i < fruitTransforms.Length; i++)
        {
            fruitTransforms[i].GetComponent<DraggableObjectUI>().originalPosition = initialFruitTransforms[i].position;
            fruitTransforms[i].DOMove(initialFruitTransforms[i].position, tweenDuration);
        }

    }

    public void FruitDraggedToPlateCallback()
    {
        SpeechManager._instance.DisableAllSpeech();
        monkey.Joy();
        if (WordTobeAssignedIndex < WordsToBeAssignedToPlate.Length)
        {
            plate.word = WordsToBeAssignedToPlate[WordTobeAssignedIndex];
            WordTobeAssignedIndex++;
        }
        else
        {
            Stage2Finish();
        }
    }

    public void Speak()
    {
        if(!locked)
            SpeechManager._instance.ChangeSpeechBubble("put the " + plate.word + " INSIDE the bowl");
    }
    public void Stage2Finish()
    {
        locked = true;
        SpeechManager._instance.DisableAllSpeech();
        button_stage_3.gameObject.SetActive(true);

        for (int i = 0; i < fruitTransforms.Length; i++)
        {
            fruitTransforms[i].GetComponent<Image>().raycastTarget= false;
        }
    }
}

