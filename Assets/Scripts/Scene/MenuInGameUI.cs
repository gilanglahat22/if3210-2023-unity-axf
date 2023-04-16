using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInGameUI : MonoBehaviour
{
    public void redirectToMainScene(){
        SceneManager.LoadScene(GameStates.getCurrentMainScene());
    }
    public void redirectToSaveGame(){
        SceneManager.LoadScene("Save_Game");
    } 
    public void redirectToStartGame(){
        SceneManager.LoadScene("Start_Game");
    }
}