using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Stage1 : MonoBehaviour
{

    public RectTransform[] fruitTransforms;
    public UIPlate plate;

    public float tweenDuration;

    private int currentFruitIndex = 0;


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
        LetterAnimationSound._instance.word = "INSIDE";
        LetterAnimationSound._instance.GenerateWord();
    }

    [ContextMenu("tweenFruit")]
    public void MoveFruitToPlate()
    {
        if(currentFruitIndex < fruitTransforms.Length){
            //move fruit to plates here is temporary jsut for testing
            fruitTransforms[currentFruitIndex].DOMove(plate.fruitPositions[currentFruitIndex].position, tweenDuration).OnComplete(StartTweeningLetters);//start tweening letter of the word INSIDE
        }
    }

    //tween letters after sound has finished playing
    private void StartTweeningLetters()
    {
        //display text
        fruitTransforms[currentFruitIndex].GetComponent<AudioSource>().Play();
        StartCoroutine(WaitForSound());
    }
    public IEnumerator WaitForSound()
    {
        yield return new WaitUntil(() => fruitTransforms[currentFruitIndex].GetComponent<AudioSource>().isPlaying == false);
        // or yield return new WaitWhile(() => audiosource.isPlaying == true);
        LetterAnimationSound._instance.TweenLetters();
        currentFruitIndex++;
    }
}
