using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public GameObject popUpObj;
    public GameObject saveGame;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public Text Slot1Name;
    public Text Slot2Name;
    public Text Slot3Name;
    public InputField nameToSave1;
    public Text feedbackTemp1;
    public InputField nameToSave2;
    public Text feedbackTemp2;
    public InputField nameToSave3;
    public Text feedbackTemp3;
    private bool isGamePaused = false;
    // Start is called before the first frame update
    void Awake()
    {
        setPopUpOFF();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isGamePaused) {
                setPopUpOFF();
            }
            else setPopUpON();
        }
    }

    public void setPopUpOFF(){
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = GameStates.getCameraPosition();
        popUpObj.SetActive(false);
        saveGame.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void setPopUpON(){
        popUpObj.SetActive(true);
        saveGame.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    // public void setGameOver(){

    // }

    public void redirectToSaveGame(){
        GameStates.loadSlotNameData();
        Slot1Name.text = GameStates.getSlot1Name();
        Slot2Name.text = GameStates.getSlot2Name();
        Slot3Name.text = GameStates.getSlot3Name();
        popUpObj.SetActive(false);
        saveGame.SetActive(true);
    }

    public void backToMenuInGame(){
        popUpObj.SetActive(true);
        saveGame.SetActive(false);
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
    }

    public void backToSaveGame(){
        GameStates.loadSlotNameData();
        Slot1Name.text = GameStates.getSlot1Name();
        Slot2Name.text = GameStates.getSlot2Name();
        Slot3Name.text = GameStates.getSlot3Name();
        popUpObj.SetActive(false);
        saveGame.SetActive(true);
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
    }

    public void redirectToStartGame(){
        SceneManager.LoadScene("Start_Game");
    }
    public void redirectToSaveSlot1(){
        saveGame.SetActive(false);
        slot1.SetActive(true);
    }
    public void redirectToSaveSlot2(){
        saveGame.SetActive(false);
        slot2.SetActive(true);
    }
    public void redirectToSaveSlot3(){
        saveGame.SetActive(false);
        slot3.SetActive(true);
    }
    public void tryAgain(){
        GameStates.resetGameForTryAgain();
        SceneManager.LoadScene(GameStates.getCurrentMainScene());
    }

    public void saveToSlot1(){
        string tempname;
        if(nameToSave1.text.Length==0) tempname = "DEFAULT";
        else tempname = nameToSave1.text;
        GameStates.setSlot1Name(tempname);
        GameStates.saveSlotData1();
        GameStates.saveSlotNameData();
        feedbackTemp1.text = "Your data has been saved...";
        backToSaveGame();
    }
    public void saveToSlot2(){
        string tempname;
        if(nameToSave2.text.Length==0) tempname = "DEFAULT";
        else tempname = nameToSave2.text;
        GameStates.setSlot2Name(tempname);
        GameStates.saveSlotData2();
        GameStates.saveSlotNameData();
        feedbackTemp2.text = "Your data has been saved...";
        backToSaveGame();
    }
    public void saveToSlot3(){
        string tempname;
        if(nameToSave3.text.Length==0) tempname = "DEFAULT";
        else tempname = nameToSave3.text;
        GameStates.setSlot3Name(tempname);
        GameStates.saveSlotData3();
        GameStates.saveSlotNameData();
        feedbackTemp3.text = "Your data has been saved...";
        backToSaveGame();
    }
    
}
