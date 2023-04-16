using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveGameUI : MonoBehaviour
{
    public Text Slot1Name;
    public Text Slot2Name;
    public Text Slot3Name;
    void Awake(){
        GameStates.loadSlotNameData();
        Slot1Name.text = GameStates.getSlot1Name();
        Slot2Name.text = GameStates.getSlot2Name();
        Slot3Name.text = GameStates.getSlot3Name();
    }
    public void BackScene(){
        SceneManager.LoadScene(GameStates.getCurrentMainScene());
    }
    public void redirectToSaveSlot1(){
        SceneManager.LoadScene("SaveSlot1");
    }
    public void redirectToSaveSlot2(){
        SceneManager.LoadScene("SaveSlot2");
    }
    public void redirectToSaveSlot3(){
        SceneManager.LoadScene("SaveSlot3");
    }
}
