using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManage : MonoBehaviour
{

    public AudioClip gameLose;
    public AudioClip click;

    public AudioClip walk;
    public AudioClip attack;
    public AudioClip jump;

    public AudioMixer mixer;
    public AudioSource audioSource;
    
    public static SoundManage instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BGSoundVolume(float val)
    {
        mixer.SetFloat("BGM", Mathf.Log10(val) * 20);
    }
    public void SFXVolume(float val)
    {
        mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }


    public void SFXPlay(string sfxname, AudioClip clip)
    {
        GameObject go = new GameObject(sfxname + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audiosource.clip = clip;
        audiosource.Play();
        Destroy(go, clip.length);
    }

    public void ButtonDownSound()
    {
        instance.SFXPlay("ButtonDown", click);
    }
    public void GameLose()
    {
        instance.SFXPlay("GameLose", gameLose);
    }
}
