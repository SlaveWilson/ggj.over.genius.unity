using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // reference
    public static SoundManager instance;

    // AudioSource
    public AudioSource _BGMSpeaker;
    public AudioSource _SESpeaker;
    public AudioSource _UISpeaker;
    public AudioSource _LoopSESpeaker;
    public AudioSource _CVSpeaker;

    public static AudioSource BGMSpeaker;
    public static AudioSource SESpeaker;
    public static AudioSource UISpeaker;
    public static AudioSource LoopSESpeaker;
    public static AudioSource CVSpeaker;

    [Header("Please choose BGM and SE")]
    // AudioClip
    public AudioClip _mainGameBGM;
    public static AudioClip mainGameBGM;


    public AudioClip _readySE;
    public static AudioClip readySE;
    public AudioClip _goSE;
    public static AudioClip goSE;
    public AudioClip _timesUpSE;
    public static AudioClip timesUpSE;


    public List<AudioClip> _newOrderSE;
    public static List<AudioClip> newOrderSE;
    public List<AudioClip> _allCorrectRepairSE;
    public static List<AudioClip> allCorrectRepairSE;
    public AudioClip _wrongRepairSE;
    public static AudioClip wrongRepairSE;


    public AudioClip _clickButtonSE;
    public static AudioClip clickButtonSE;


    void Awake()
    {
        instance = this;

        // assign static variables
        BGMSpeaker = _BGMSpeaker;
        SESpeaker = _SESpeaker;
        UISpeaker = _UISpeaker;
        LoopSESpeaker = _LoopSESpeaker;
        CVSpeaker = _CVSpeaker;


        mainGameBGM = _mainGameBGM;


        readySE = _readySE;
        goSE = _goSE;
        timesUpSE = _timesUpSE;


        newOrderSE = _newOrderSE;
        allCorrectRepairSE = _allCorrectRepairSE;
        wrongRepairSE = _wrongRepairSE;


        clickButtonSE = _clickButtonSE;



        float bgmVolume = PlayerPrefs.GetFloat("BGMVol", 1);
        float seVolume = PlayerPrefs.GetFloat("SEVol", 1);
        float cvVolume = PlayerPrefs.GetFloat("CVVol", 1);


        SoundManager.BGMSpeaker.volume = bgmVolume;

        SoundManager.SESpeaker.volume = seVolume;
        SoundManager.LoopSESpeaker.volume = seVolume;
        SoundManager.UISpeaker.volume = seVolume;

        SoundManager.CVSpeaker.volume = cvVolume;

        BGMSpeaker.loop = true;
        SESpeaker.loop = false;
        UISpeaker.loop = false;
        LoopSESpeaker.loop = true;
        CVSpeaker.loop = false;

        BGMSpeaker.playOnAwake = true;
        SESpeaker.playOnAwake = false;
        UISpeaker.playOnAwake = false;
        LoopSESpeaker.playOnAwake = false;
        CVSpeaker.playOnAwake = false;
    }

    public static void PlayBGM(AudioClip audioClip)
    {
        if (BGMSpeaker == null) return;
        BGMSpeaker.clip = audioClip;
        BGMSpeaker.Play();
    }

    public static void PlaySE(AudioClip audioClip)
    {
        if (SESpeaker == null) return;
        SESpeaker.clip = audioClip;
        SESpeaker.PlayOneShot(audioClip);
    }

    public static void PlayUI(AudioClip audioClip)
    {
        UISpeaker.clip = audioClip;
        UISpeaker.Play();
    }

    public static void PlayLoopSE(AudioClip audioClip)
    {
        LoopSESpeaker.clip = audioClip;
        LoopSESpeaker.Play();
    }

    public static void PauseLoopSE()
    {
        LoopSESpeaker.Pause();
    }

    public static void StopLoopSE()
    {
        LoopSESpeaker.Stop();
    }

    public static void UnPauseLoopSE()
    {
        LoopSESpeaker.Play();
    }

    public static void PlayCV(AudioClip audioClip, bool Interupt = true)
    {
        if (!CVSpeaker.isPlaying || (CVSpeaker.isPlaying && Interupt))
        {
            CVSpeaker.clip = audioClip;
            CVSpeaker.Play();
        }

    }

    public static void StopCV()
    {
        CVSpeaker.Stop();
    }







    public static void ReadySE()
    {
        Debug.Log("ReadySE()");
        PlaySE(readySE);
    }
    public static void GoSE()
    {
        Debug.Log("GoSE()");
        PlaySE(goSE);
    }
    public static void TimesUpSE()
    {
        Debug.Log("TimesUpSE()");
        PlaySE(timesUpSE);
    }




    public static void NewOrderSE()
    {

    }
    public static void CorrectRepairSE(int type)
    {
        Debug.Log("CorrectRepairSE(int type)");
        PlaySE(allCorrectRepairSE[type]);
    }
    public static void WrongRepairSE()
    {
        Debug.Log("WrongRepairSE()");
        PlaySE(wrongRepairSE);
    }
  
    public static void ClickButtonSE()
    {
        Debug.Log("ClickButtonSE()");
        PlaySE(clickButtonSE);
    }
}
