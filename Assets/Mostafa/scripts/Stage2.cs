using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Audio;

public class Stage2 : MonoBehaviour
{

    public RectTransform[] fruitTransforms;

    public RectTransform[] initialFruitTransforms;//go to those positions when button is clicked

    public RectTransform finger;

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
        finger.gameObject.SetActive(true);
        button_stage_2.gameObject.SetActive(false);
        plate.word = WordsToBeAssignedToPlate[WordTobeAssignedIndex];
        MonkeyChair();
        TweenFruitsBackToTable();
        WordTobeAssignedIndex++;

        for (int i = 0; i < fruitTransforms.Length; i++)
        {
            fruitTransforms[i].GetComponent<Image>().raycastTarget = true;
        }
        //make monkey talk
    }

    public void MoveFinger()
    {
        //move finger to current fruit
        Vector2 current_fruit_pos;

        foreach (RectTransform fr in fruitTransforms)
        {

            if (fr.GetComponent<DraggableObjectUI>().objectText == plate.word)
            {
                Debug.Log("fingering");
                current_fruit_pos = fr.position;
                current_fruit_pos.y -= 50;
                finger.position = current_fruit_pos;
                break;
            }
        }
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
            fruitTransforms[i].DOMove(initialFruitTransforms[i].position, tweenDuration).OnComplete(MoveFinger);
        }

    }

    public void FruitDraggedToPlateCallback()
    {

        monkey.Joy();
        if (WordTobeAssignedIndex < WordsToBeAssignedToPlate.Length)
        {
            plate.word = WordsToBeAssignedToPlate[WordTobeAssignedIndex];
            WordTobeAssignedIndex++;
            MoveFinger();
        }
        else
        {
           StartCoroutine(startFinishingStage2());
        }
    }

    public void Speak()
    {
        if (locked) return;

        SpeechManager._instance.ChangeSpeechBubble("put the " + plate.word + " INSIDE the bowl");
        GeneralAudioManager._instance.playStage2FruitInside(plate.word);
    }

    IEnumerator startFinishingStage2()
    {

        yield return new WaitUntil(() => GeneralAudioManager._instance.audiosource.isPlaying == false);
        Stage2Finish();
    }
    public void Stage2Finish()
    {
        locked = true;
        SpeechManager._instance.DisableAllSpeech();
        button_stage_3.gameObject.SetActive(true);
        finger.gameObject.SetActive(false);
        for (int i = 0; i < fruitTransforms.Length; i++)
        {
            fruitTransforms[i].GetComponent<Image>().raycastTarget = false;
        }
    }
}

