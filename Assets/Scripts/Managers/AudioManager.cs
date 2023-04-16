using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudio;
    private bool isStop = false;
    void Awake(){
        musicAudio.loop = true;
        isStop = false;
        musicAudio.Play();
        setMusicVolume(AudioSettings.getVolumeMusic());
        setMusicMute(!AudioSettings.getIsOnMusic());
    }
    // void OnDestroy(){
    //     isStop = true;
    //     musicAudio.Stop();
    // }
    
    void Update(){
        if(!isStop){
            setMusicVolume(AudioSettings.getVolumeMusic());
            setMusicMute(!AudioSettings.getIsOnMusic());
        }
    }

    public void setMusicVolume(float value){
        musicAudio.volume = value;
    }

    public void setMusicMute(bool isMute){
        musicAudio.mute = isMute;
    }

}
