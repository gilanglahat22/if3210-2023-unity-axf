using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlot1UI : MonoBehaviour
{
    public InputField nameToSave;
    public Text feedbackTemp;
    public void saveToSlot1(){
        string tempname;
        if(nameToSave.text.Length==0) tempname = "DEFAULT";
        else tempname = nameToSave.text;
        GameStates.setSlot1Name(tempname);
        GameStates.saveSlotData1();
        GameStates.saveSlotNameData();
        feedbackTemp.text = "Your data has been saved...";
        SceneManager.LoadScene("Save_Game");
    }
    public void BackScene(){
        SceneManager.LoadScene("Save_Game");
    }
}
 