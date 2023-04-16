using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioSettingsData
{
    public float musicVolume;
    public float soundVolume;

    public bool isMusicON;
    public bool isSoundON;

    public AudioSettingsData(){
        this.musicVolume = 0.5f;
        this.soundVolume = 1f;
        this.isMusicON = true;
        this.isSoundON = true;
    }

    public AudioSettingsData(float musicVolumeUpdated, float soundVolumeUpdated, bool isOnMusicUpdated, bool isOnSoundUpdated){
        this.musicVolume = musicVolumeUpdated;
        this.soundVolume = soundVolumeUpdated;
        this.isMusicON = isOnMusicUpdated;
        this.isSoundON  = isOnSoundUpdated;
    }
}
