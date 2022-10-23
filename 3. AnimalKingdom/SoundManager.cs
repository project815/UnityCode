using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource bgSound;

    public AudioClip[] bglist;
    
    public AudioSource SFX;


    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "0. intro")
            BgSoundPlay(bglist[4]);
        if (arg0.name == "game")
        {
            if (PlayerMessager.val == 0 || PlayerMessager.val == 1)
                BgSoundPlay(bglist[0]); //desert wind
            if (PlayerMessager.val == 2)
                BgSoundPlay(null);
            if (PlayerMessager.val == 3)
                BgSoundPlay(bglist[1]); //Quiet_forest_bird
            if (PlayerMessager.val == 4)
                BgSoundPlay(null);
            if (PlayerMessager.val == 5 || PlayerMessager.val == 6)
                BgSoundPlay(bglist[2]); //Forest_brid wind
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 ||
            SceneManager.GetActiveScene().buildIndex == 3 ||
            SceneManager.GetActiveScene().buildIndex == 4 ||
            SceneManager.GetActiveScene().buildIndex == 5 ||
            SceneManager.GetActiveScene().buildIndex == 6||
            SceneManager.GetActiveScene().buildIndex == 7)
        {
            BgSoundPlay(bglist[3]);
        }
        
    }

    public void SFXPlay(string sfxname, AudioClip clip) //instance
    {
        GameObject go = new GameObject(sfxname + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audiosource.clip = clip;
        audiosource.Play();
        Destroy(go, clip.length);
    }
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 1f;
        bgSound.Play();
    }
    public void SFX_Play(AudioClip clip) //child (MoveScene Don't removeSound)
    {
        SFX.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        SFX.clip = clip;
        SFX.loop = false;
        SFX.volume = 1f;
        SFX.Play();
    }

    public void BGSoundVolume(float val)
    {
        mixer.SetFloat("BGM", Mathf.Log10(val) * 20);
    }
    public void SFXSoundVolume(float val)
    {
        mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }    

}