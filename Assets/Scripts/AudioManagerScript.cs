using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    public AudioClip TapSound;
    public AudioClip WrongTapSound;
    public AudioClip CollectingItemSound;
    public AudioClip GettingIntoBasketSound;
    public AudioClip ItemChangeSound;
    public AudioClip EvaluationSound;
    public AudioClip FinishingSound;
    public AudioClip BackgroundMusic;


    [Range(0.0f, 1f)]
    public float TapSoundVolume;
    [Range(0.0f, 1f)]
    public float WrongTapSoundVolume;
    [Range(0.0f, 1f)]
    public float CollectingItemSoundVolume;
    [Range(0.0f, 1f)]
    public float GettingIntoBasketSoundVolume;
    [Range(0.0f, 1f)]
    public float ItemChangeSoundVolume;
    [Range(0.0f, 1f)]
    public float EvaluationSoundVolume;
    [Range(0.0f, 1f)]
    public float FinishingSoundVolume;
    [Range(0.0f, 1f)]
    public float BackgroundMusicVolume;


    [Range(0, 256)]
    public int TapSoundPriority;
    [Range(0, 256)]
    public int WrongTapSoundPriority;
    [Range(0, 256)]
    public int CollectingItemSoundPriority;
    [Range(0, 256)]
    public int GettingIntoBasketSoundPriority;
    [Range(0, 256)]
    public int ItemChangeSoundPriority;
    [Range(0, 256)]
    public int EvaluationSoundPriority;
    [Range(0, 256)]
    public int FinishingSoundPriority;
    [Range(0, 256)]
    public int BackgroundMusicPriority;


    public AudioSource TapSoundSrc;
    public AudioSource WrongTapSoundSrc;
    public AudioSource CollectingItemSoundSrc;
    public AudioSource GettingIntoBasketSoundSrc;
    public AudioSource ItemChangeSoundSrc;
    public AudioSource EvaluationSoundSrc;
    public AudioSource FinishingSoundSrc;
    public AudioSource BackgroundMusicSrc;




    public void PlayTapSound()
    {
        TapSoundSrc.priority = TapSoundPriority;
        TapSoundSrc.volume = TapSoundVolume;
        TapSoundSrc.PlayOneShot(TapSound);
    }


    public void PlayWrongTapSound()
    {
        WrongTapSoundSrc.priority = WrongTapSoundPriority;
        WrongTapSoundSrc.volume = WrongTapSoundVolume;
        WrongTapSoundSrc.PlayOneShot(WrongTapSound);
    }


    public void PlayCollectingItemSound()
    {
        CollectingItemSoundSrc.priority = CollectingItemSoundPriority;
        CollectingItemSoundSrc.volume = CollectingItemSoundVolume;
        CollectingItemSoundSrc.PlayOneShot(CollectingItemSound);
    }


    public void PlayGettingIntoBasketSound()
    {
        GettingIntoBasketSoundSrc.priority = GettingIntoBasketSoundPriority;
        GettingIntoBasketSoundSrc.volume = GettingIntoBasketSoundVolume;
        GettingIntoBasketSoundSrc.PlayOneShot(GettingIntoBasketSound);
    }


    public void PlayItemChangeSound()
    {
        ItemChangeSoundSrc.priority = ItemChangeSoundPriority;
        ItemChangeSoundSrc.volume = ItemChangeSoundVolume;
        ItemChangeSoundSrc.PlayOneShot(ItemChangeSound);
    }


    public void PlayEvaluationSound()
    {
        EvaluationSoundSrc.priority = EvaluationSoundPriority;
        EvaluationSoundSrc.volume = EvaluationSoundVolume;
        EvaluationSoundSrc.PlayOneShot(EvaluationSound);
    }


    public void PlayFinishingSound()
    {
        FinishingSoundSrc.priority = FinishingSoundPriority;
        FinishingSoundSrc.volume = FinishingSoundVolume;
        FinishingSoundSrc.PlayOneShot(FinishingSound);
    }


    public void PlayBackgroundMusic()
    {
        //BackgroundMusic.Play(BackgroundMusic);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
