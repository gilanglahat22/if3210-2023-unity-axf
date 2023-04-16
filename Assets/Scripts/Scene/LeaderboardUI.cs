using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardUI : MonoBehaviour
{
    public RowLeaderboardUI rowUi;
    public SaveLoadLeaderboard gameState;
    
    void Start()
    {
        // gameState.AddScore(new Score("Veteran",17));
        var dataScores = gameState.GetListSortedDesc().ToArray();
        for (int i = 0; i < dataScores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowLeaderboardUI>();
            if(i+1==1) row.rank.text = "1ST";
            else if(i+1==2) row.rank.text = "2ND";
            else if(i+1==3) row.rank.text = "3RD";
            else row.rank.text = (i + 1).ToString()+"TH";
            row.name.text = dataScores[i].name;
            row.duration.text = dataScores[i].duration.ToString();
        }
    }

    public void backToMainMenu(){
        SceneManager.LoadScene("Start_Game");
    }
}