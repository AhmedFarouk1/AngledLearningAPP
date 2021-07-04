using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LetterAnimationSound : MonoBehaviour
{
    public string word;
    public float horiziontalSpacing;
    public float tween_duration;
    public GameObject letterPrefab;

    public UnityEvent onFinishAnimation;

    private List<GameObject> instantiated_letters;

    public RectTransform y_destination;

    public AudioSource Inside_Split;
    public AudioSource Outside_Split;


    public static LetterAnimationSound _instance;
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


    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        instantiated_letters = new List<GameObject>();
        rectTransform = GetComponent<RectTransform>();
    }

    [ContextMenu("generate word")]
    public void GenerateWord()
    {
        current_tween_index = 0;
        foreach(var i in instantiated_letters)
        {
            Destroy(i);
        }
        instantiated_letters = new List<GameObject>();
        for (int i = 0; i < word.Length; i++)
        {
            Vector2 tmpPosition = rectTransform.position;
            GameObject tmpLetterGO = Instantiate(letterPrefab, rectTransform);
            instantiated_letters.Add(tmpLetterGO);
            tmpLetterGO.GetComponent<UILetter>().AssignLetter(word[i].ToString());
            tmpPosition.x += i * horiziontalSpacing;
            tmpLetterGO.transform.position = tmpPosition;
            tmpLetterGO.GetComponent<UIDrag>().dragEnabled = false;
        }
    }



    /*
     * move letters to destination transform
     */
    private int current_tween_index;
    [ContextMenu("tween_letters")]
    public void TweenLetters()
    {
        if(current_tween_index < word.Length)
        {
            Vector2 tmpPos;
            tmpPos.y = y_destination.position.y;
            tmpPos.x = instantiated_letters[current_tween_index].GetComponent<RectTransform>().position.x;

            instantiated_letters[current_tween_index].GetComponent<RectTransform>().DOMove(tmpPos, tween_duration).OnComplete(TweenLetters);
            current_tween_index++;
            return;
        }
        current_tween_index = 0;
        onFinishAnimation.Invoke();
        GenerateWord();
    }

    public void PlaySoundSplitInside()
    {
        Inside_Split.Play();
    }

    public void PlaySoundSplitOutside()
    {
        Outside_Split.Play();
    }
}
