using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Stage1 : MonoBehaviour
{

    public RectTransform[] fruitTransforms;
    public UIPlate plate;

    public Monkey monkey;

    public Button button_stage_1;
    public Button button_stage_2;

    public float tweenDuration;

    private int currentFruitIndex = 0;

    bool locked = false; // if true locks all actions related to stage 1

    public static Stage1 _instance;
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

    private void Start()
    {

    }

    public void OnStage1BtnClick()
    {
        button_stage_1.gameObject.SetActive(false);
        monkey.doneJumping = false;
        monkey.Jump();
    }

    [ContextMenu("tweenFruit")]
    public void MoveFruitToPlate()
    {
        if (locked) return;

        LetterAnimationSound._instance.word = "INSIDE";
        LetterAnimationSound._instance.GenerateWord();

        if (currentFruitIndex < fruitTransforms.Length)
        {
            //move fruit to plates here is temporary jsut for testing
            fruitTransforms[currentFruitIndex].DOMove(plate.fruitPositions[currentFruitIndex].position, tweenDuration).OnComplete(StartTweeningLetters);//start tweening letter of the word INSIDE
        }
        else
        {
            Stage1Finish();
        }

    }

    //tween letters after sound has finished playing
    private void StartTweeningLetters()
    {
        if (locked) return;
        //display text
        fruitTransforms[currentFruitIndex].GetComponent<AudioSource>().Play();
        SpeechManager._instance.ChangeSubtitle("the " + fruitTransforms[currentFruitIndex].GetComponent<DraggableObjectUI>().objectText + " is INSIDE the bowl");
        StartCoroutine(WaitForSound());
    }
    public IEnumerator WaitForSound()
    {
        yield return new WaitUntil(() => fruitTransforms[currentFruitIndex].GetComponent<AudioSource>().isPlaying == false);
        // or yield return new WaitWhile(() => audiosource.isPlaying == true);
        LetterAnimationSound._instance.TweenLetters();
        LetterAnimationSound._instance.PlaySoundSplitInside();
        currentFruitIndex++;
    }

    public void Stage1Finish()
    {
        if (locked) return;
        locked = true;
        button_stage_2.gameObject.SetActive(true);
        SpeechManager._instance.DisableAllSpeech();
        //enable button two
        LetterAnimationSound._instance.onFinishAnimation.RemoveAllListeners();
    }
}
