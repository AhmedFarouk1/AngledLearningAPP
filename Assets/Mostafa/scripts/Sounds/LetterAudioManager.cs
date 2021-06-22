using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LetterAudioManager : MonoBehaviour
{
    public List<LetterAudio> letteraudio;
    public AudioClip swinging;
    public AudioSource audiosource;

    public static LetterAudioManager _instance;
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


    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();    
    }

    public void playLetter(string letter)
    {
        letter = letter.ToLower();
        LetterAudio letterAudio = letteraudio.Find(audio => audio.Letter == letter);
        if (letterAudio != null)
        {
            audiosource.clip = letterAudio.sound;
            audiosource.Play();
        }

        Debug.Log(letter);
    }

    //this functions houldn't be here
    public void monkeySwing()
    {
        audiosource.clip = swinging;
        audiosource.Play();
    }
}
