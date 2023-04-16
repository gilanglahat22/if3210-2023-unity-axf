using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject LoadGame;
    public GameObject Leaderboard;
    public Text currentPlayerName;
    public InputField inputPlayerName;
    public Slider musicSlider;
    public Slider soundSlider;
    private bool startMusicToggle, startSoundToggle;
    private float startMusicVol, startSoundVol;

    public Toggle musicToggle;
    public Toggle soundToggle;
    private string placeNow;

    private bool isSave;

    public Text Slot1Name;
    public Text Slot2Name;
    public Text Slot3Name;

    void Awake(){
        AudioSettings.loadMusicConfData();
        GameStates.loadSlotNameData();
        this.placeNow = "Menu";
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        LoadGame.SetActive(false);
        Leaderboard.SetActive(false);
        this.isSave = true;
    }

    void Update(){
        if(this.placeNow == "Settings" && isSave){
            AudioSettings.setVolumeMusic(musicSlider.value);
            AudioSettings.setVolumeSound(soundSlider.value);
            AudioSettings.setIsOnMusic(musicToggle.isOn);
            AudioSettings.setIsOnSound(soundToggle.isOn);
        }else if(this.placeNow == "Menu"){
            this.isSave = true;
            currentPlayerName.text = GameStates.getCurrentPlayerName();
            musicSlider.value = AudioSettings.getVolumeMusic();
            soundSlider.value = AudioSettings.getVolumeSound();
            musicToggle.isOn = AudioSettings.getIsOnMusic();
            soundToggle.isOn = AudioSettings.getIsOnSound();
            startMusicVol = AudioSettings.getVolumeMusic();
            startSoundVol = AudioSettings.getVolumeSound();
            startMusicToggle = AudioSettings.getIsOnMusic();
            startSoundToggle = AudioSettings.getIsOnSound();
        }
        Slot1Name.text = GameStates.getSlot1Name();
        Slot2Name.text = GameStates.getSlot2Name();
        Slot3Name.text = GameStates.getSlot3Name();
    }

    public void StartGame(){
        // GameStates.setCurrentIndexQuest(0);
        GameStates.resetGame();
        SceneManager.LoadScene("OpeningScene1");
    }
    public void redirectToSettings(){
        MainMenu.SetActive(false);
        Settings.SetActive(true);
        // LoadGame.SetActive(false);
        this.placeNow = "Settings";
        // SceneManager.LoadScene("Settings");
    }
    public void saveSettings(){
        GameStates.setPlayerName(inputPlayerName.text);
        AudioSettings.saveMusicConfData();
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        // LoadGame.SetActive(false);
        this.placeNow = "Menu";
    }
    public void BackSceneSettings(){
        isSave = false;
        AudioSettings.setVolumeMusic(startMusicVol);
        AudioSettings.setVolumeSound(startSoundVol);
        AudioSettings.setIsOnMusic(startMusicToggle);
        AudioSettings.setIsOnSound(startSoundToggle);
        AudioSettings.saveMusicConfData();
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        // LoadGame.SetActive(false);
        this.placeNow = "Menu";
    }
    public void redirectToLeaderboard(){
        MainMenu.SetActive(false);
        Leaderboard.SetActive(true);
        // SceneManager.LoadScene("Leaderboard");
    }

    public void backSceneLeaderboard(){
        MainMenu.SetActive(true);
        Leaderboard.SetActive(false);
        this.placeNow = "Menu";
    }

    public void redirectToLoadGame(){
        MainMenu.SetActive(false);
        // Settings.SetActive(false);
        LoadGame.SetActive(true);
    }

    public void loadSlot1(){
        GameStates.loadDataSlot1();
        SceneManager.LoadScene(GameStates.getCurrentMainScene());
    }

    public void loadSlot2(){
        GameStates.loadDataSlot2();
        SceneManager.LoadScene(GameStates.getCurrentMainScene());
    }

    public void loadSlot3(){
        GameStates.loadDataSlot3();
        SceneManager.LoadScene(GameStates.getCurrentMainScene());
    }
    public void BackSceneLoad(){
        MainMenu.SetActive(true);
        // Settings.SetActive(false);
        LoadGame.SetActive(false);
        this.placeNow = "Menu";
    }
    public void exitGame(){
        Application.Quit();
    }
}
