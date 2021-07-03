using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Stage3 : MonoBehaviour
{

    public RectTransform[] fruitTransforms;
    public RectTransform[] destinationFruitTransforms;//go to those positions when button is clicked

    public RectTransform monkeyTablePosition;
    public RectTransform monkeyChairPosition;

    public UILettersMiniGame lettersMiniGame;

    public UIPlate plate;
    public Monkey monkey;
    public Button button_stage_3;

    public float tweenDuration;
    private int currentFruitIndex = 0;

    bool locked = false; // if true locks all actions related to stage 1

    public static Stage3 _instance;
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


    public void OnStage3BtnClick()
    {
        SpeechManager._instance.DisableAllSpeech();
        Stage2._instance.TweenFruitsBackToTable();//that's cheating :D
        lettersMiniGame.gameObject.SetActive(true);
        lettersMiniGame.Prepare();
        button_stage_3.gameObject.SetActive(false);
        SpeechManager._instance.ChangeSpeechBubble("keep the letters of INSIDE in order");
        GeneralAudioManager._instance.keepInsideOrder();
    }

    public void MoveFruitToPlate()
    {
        monkey.FlipMonkey();
        monkey.Inside();
        if (currentFruitIndex < fruitTransforms.Length)
        {
            fruitTransforms[currentFruitIndex].DOMove(plate.fruitPositions[currentFruitIndex].position, tweenDuration).OnComplete(restart);//start tweening letter of the word INSIDE
            currentFruitIndex++;
        }

        
       

    }

    public void wordCompleted()//execute when the kid completes a word
    {
        monkey.GetComponent<Animator>().SetBool("gotochair", true);
        monkey.GetComponent<RectTransform>().DOMove(monkeyTablePosition.position, tweenDuration).OnComplete(MoveFruitToPlate);
    }

    public void restart()
    {
        if (currentFruitIndex < fruitTransforms.Length)
        {
            monkey.GetComponent<Animator>().SetBool("gotochair", true);
            monkey.GetComponent<RectTransform>().DOMove(monkeyChairPosition.position, tweenDuration).OnComplete(monkey.FlipMonkey);
            lettersMiniGame.Prepare();
        }
        else
        {
            Stage3Finish();
        }
    }

    public void Stage3Finish()
    {
        if (locked) return;
        locked = true;

        SpeechManager._instance.ChangeSubtitle("Congratulations!!! you've learned INSIDE!");
        GetComponent<AudioSource>().Play();
    }
}
