using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlot2UI : MonoBehaviour
{
    public InputField nameToSave;
    public Text feedbackTemp;
    public void saveToSlot2(){
        string tempname;
        if(nameToSave.text.Length==0) tempname = "DEFAULT";
        else tempname = nameToSave.text;
        GameStates.setSlot2Name(tempname);
        GameStates.saveSlotData2();
        GameStates.saveSlotNameData();
        feedbackTemp.text = "Your data has been saved...";
        SceneManager.LoadScene("Save_Game");
    }
    public void BackScene(){
        SceneManager.LoadScene("Save_Game");
    }
}
