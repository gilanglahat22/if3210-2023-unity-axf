using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveLoadLeaderboard : MonoBehaviour
{
    void Awake()
    {
        GameStates.loadLeaderboard();
    }

    void Update(){
        GameStates.saveLeaderboard();
    }

    public IEnumerable<Score> GetListSortedDesc()
    {
        return GameStates.getLeaderboardList().dataScores.OrderBy(x => x.duration);
    }

    public void AddScore(string name, double duration)
    {
        GameStates.addLeaderboard(name, duration);
    }

    private void OnDestroy()
    {
        GameStates.saveLeaderboard();
    }
}
