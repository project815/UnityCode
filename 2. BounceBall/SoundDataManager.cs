using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundDataManager : MonoBehaviour
{
    public Slider BGM;
    public Slider SFX;


    // Start is called before the first frame update
    void Start()
    {
        //게임 시작할 떄 게임 데이터를 불러오고 시작해야 한다.
        //사운드믹서 값에 저장된 값을 집어넣고 시작하자.

            BGM.value = PlayerPrefs.GetFloat("FILE_BGM_Sound");
            SFX.value = PlayerPrefs.GetFloat("FILE_SFX_Sound");

    }
    //void OnEnable()
    //{
    //    BGM.value = BGM_Save;
        
    //}
    // Update is called once per frame
    void OnDisable()
    {
        PlayerPrefs.SetFloat("FILE_BGM_Sound", BGM.value);
        PlayerPrefs.SetFloat("FILE_SFX_Sound", SFX.value);
    }

}
