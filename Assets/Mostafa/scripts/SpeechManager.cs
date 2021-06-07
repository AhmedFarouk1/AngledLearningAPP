using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
*module responsible for rendering speech text
*/
public class SpeechManager : MonoBehaviour
{
    public Text subtitle;
    public Text SpeechBubble;
    public GameObject SpeechBubbleGO;

    // Start is called before the first frame update
    public static SpeechManager _instance;
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


    public void ChangeSubtitle(string s)
    {
        subtitle.gameObject.SetActive(true);
        subtitle.text = s;
    }

    public void ChangeSpeechBubble(string s)
    {
        SpeechBubbleGO.SetActive(true);
        SpeechBubble.text = s;
    }

    public void DisableAllSpeech()
    {
        subtitle.gameObject.SetActive(false);
        SpeechBubbleGO.SetActive(false);
    }
}
