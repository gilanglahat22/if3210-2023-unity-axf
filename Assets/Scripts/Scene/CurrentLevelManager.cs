using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevelManager : MonoBehaviour
{
    public int current_level;
    void Awake(){
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = GameStates.getCameraPosition();
        // Debug.Log("Ini posisi Camera: "+GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        // Debug.Log("Ini posisi Orang: "+GameStates.getCurrCoordinat());
        if(current_level==1)GameStates.setCurrentIndexQuest(0);
        else if(current_level==2) GameStates.setCurrentIndexQuest(1);
        else if(current_level==3) GameStates.setCurrentIndexQuest(2);
        else GameStates.setCurrentIndexQuest(3);
        GameStates.setPoinTimeStamp(GameStates.getCurrentPoin(), GameStates.getCurrentIndexQuest());
    }
}
