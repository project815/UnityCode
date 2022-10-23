using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip cilp_ButtonDown;
    public AudioClip cilp_SettingButton;
    public AudioClip cilp_Correct;
    public AudioClip cilp_Wrong;
    public void ButtonDownPlayer()
    {
        SoundManager.instance.SFX_Play(cilp_ButtonDown);   
    }
    public void SettingButtonPlayer()
    {
        SoundManager.instance.SFX_Play(cilp_SettingButton);
    }
    public void CorrectPlayer()
    {
        SoundManager.instance.SFX_Play(cilp_Correct);
    }
    public void WrongPlayer()
    {
        SoundManager.instance.SFX_Play(cilp_Wrong);
    }

    public void BGMSoundVolume(float val)
    {
        SoundManager.instance.BGSoundVolume(val);
    }
    public void SFXSoundVolume(float val)
    {
        SoundManager.instance.SFXSoundVolume(val);
    }

}
