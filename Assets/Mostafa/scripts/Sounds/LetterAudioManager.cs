using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LetterAudioManager : MonoBehaviour
{
    public List<LetterAudio> letteraudio;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();    
    }

    public void playLetter(string letter)
    {
        audiosource.clip = letteraudio.Find(audio => audio.Letter == letter).sound;
        audiosource.Play();
    }
}
