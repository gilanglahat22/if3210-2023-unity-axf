using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public PlayerData dataPlayer;
    public EnemyData dataEnemy;
    public GameData(){
        dataPlayer = new PlayerData();
        dataEnemy = new EnemyData(0);
    }
}
