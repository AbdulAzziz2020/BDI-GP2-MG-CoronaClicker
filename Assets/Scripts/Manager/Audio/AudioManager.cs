using System;
using UnityEngine;

public class AudioManager : SingletonDontDestroyOnLoad<AudioManager>
{
    [Header("BACKGROUND MUSIC ---------------------------------------------------------------")] 
    public AudioSource sourceBGM;
    public Sound[] listBGM;

    [Space(5)]
    
    [Header("SOUND EFFECT ---------------------------------------------------------------------")]
    public AudioSource sourceSFX;
    public Sound[] listSFX;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        PlayBGM("BGM 1");
    }

    public void PlayBGM(string name)
    {
        Sound BGM = Array.Find(listBGM, bgm => bgm.name == name);
        
        if(BGM == null) Debug.LogWarning($"BGM : <color=green>{name}</color> not found!");

        sourceBGM.clip = BGM.clip;
        sourceBGM.volume = BGM.volume;
        sourceBGM.pitch = BGM.pitch;
        
        sourceBGM.Play();
    }
    
    public void PlaySFX(string name)
    {
        Sound SFX = Array.Find(listSFX, sfx => sfx.name == name);
        
        if(SFX == null) Debug.LogWarning($"SFX : <color=yellow>{name}</color> not found!");

        sourceSFX.volume = SFX.volume;
        sourceSFX.pitch = SFX.pitch;
        
        sourceSFX.PlayOneShot(SFX.clip);
    }
}
