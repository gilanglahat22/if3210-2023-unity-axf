using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static double score;

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
    }


    void Update ()
    {
        if (GameStates.getEnemyCount() != 0){
            // score += Time.deltaTime;
            if(!GameOverManager.isPauseElapsedTime) GameStates.setCurrDuration(GameStates.getCurrDuration()+Time.deltaTime);
            text.text = "Elapsed time: " + GameStates.getCurrDuration().ToString("0.00");
        }
    }
}
