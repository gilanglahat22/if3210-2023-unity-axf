using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData{
    public List<Score> dataScores;

    public ScoreData()
    {
        dataScores = new List<Score>();
    }

    public void addData(Score data){
        dataScores.Add(data);
    }
}
