using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public string name;
    public double duration;

    public Score(){
        name = "Player";
        duration = 0;
    }
    public Score(string name, double duration)
    {
        this.name = name;
        this.duration = duration;
    }
}
