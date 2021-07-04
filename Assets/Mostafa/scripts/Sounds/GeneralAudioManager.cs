using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GeneralAudioManager : MonoBehaviour
{
    public List<FruitAudio> insidefruitaudios;
    public List<FruitAudio> outsidefruitaudios;

    public AudioClip insideOrder;
    public AudioClip outsideOrder;


    public AudioClip congrat_inside_audio;
    public AudioClip congrat_outside_audio;

    public AudioSource audiosource;

    public static GeneralAudioManager _instance;
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

    public void keepInsideOrder()
    {
        audiosource.clip = insideOrder;
        audiosource.Play();
    }

    public void keepOutsideOrder()
    {
        audiosource.clip = outsideOrder;
        audiosource.Play();
    }

    public void playStage2FruitInside(string fruit_name)
    {
        fruit_name = fruit_name.ToLower();
        FruitAudio fruitAudio = insidefruitaudios.Find(audio => audio.fruit_name == fruit_name);

        if (fruitAudio != null)
        {
            audiosource.clip = fruitAudio.sound;
            audiosource.Play();
        }
    }

    public void playStage2FruitOutside(string fruit_name)
    {
        fruit_name = fruit_name.ToLower();
        FruitAudio fruitAudio = outsidefruitaudios.Find(audio => audio.fruit_name == fruit_name);
        if (fruitAudio != null)
        {
            audiosource.clip = fruitAudio.sound;
            audiosource.Play();
        }
    }

    public void congratsInside()
    {
        audiosource.clip = congrat_inside_audio;
        audiosource.Play();
    }

    public void congratsOutside()
    {
        audiosource.clip = congrat_outside_audio;
        audiosource.Play();
    }

}
