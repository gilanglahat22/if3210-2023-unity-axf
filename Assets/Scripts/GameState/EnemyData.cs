using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public int enemyCount;          // count mob monsters
    public bool spawnBossNow;       // spawn boss
    public bool isBossDefeated;     // detect boss defeated
    public bool isMiniBossSpawn;    // detect mini boss spawned
    public List<Enemy> enemyData;   // list of enemy data
    public EnemyData(int currentIndexQuest){
        this.spawnBossNow = false;
        this.isBossDefeated = false;
        this.isMiniBossSpawn = false;
        this.enemyData = new List<Enemy>();
        if(currentIndexQuest==0){
            this.enemyCount = 10;
            this.enemyData.Add(new Enemy(0, true, "Zombunny"));
            this.enemyData.Add(new Enemy(1, true, "Zombunny"));
            this.enemyData.Add(new Enemy(2, true, "Zombunny"));
            this.enemyData.Add(new Enemy(3, true, "Zombunny"));
            this.enemyData.Add(new Enemy(4, true, "Zombunny"));
            this.enemyData.Add(new Enemy(5, true, "Zombear"));
            this.enemyData.Add(new Enemy(6, true, "Zombear"));
            this.enemyData.Add(new Enemy(7, true, "Zombear"));
            this.enemyData.Add(new Enemy(8, true, "Zombear"));
            this.enemyData.Add(new Enemy(9, true, "Zombear"));
            this.enemyData.Add(new Enemy(10,false, "krookodile"));
        }else if(currentIndexQuest==1){
            this.enemyCount = 10;
            this.enemyData.Add(new Enemy(0, true, "Zombunny"));
            this.enemyData.Add(new Enemy(1, true, "Zombunny"));
            this.enemyData.Add(new Enemy(2, true, "Zombunny"));
            this.enemyData.Add(new Enemy(3, true, "Zombear"));
            this.enemyData.Add(new Enemy(4, true, "Zombear"));
            this.enemyData.Add(new Enemy(5, true, "Zombear"));
            this.enemyData.Add(new Enemy(6, true, "Zombear"));
            this.enemyData.Add(new Enemy(7, true, "Zombear"));
            this.enemyData.Add(new Enemy(8, true, "Hellephant"));
            this.enemyData.Add(new Enemy(9, true, "Hellephant"));
            this.enemyData.Add(new Enemy(10,false, "Tyranitar"));
        }else if(currentIndexQuest==2){
            this.enemyCount = 10;
            this.enemyData.Add(new Enemy(0, true, "Zombear"));
            this.enemyData.Add(new Enemy(1, true, "Zombear"));
            this.enemyData.Add(new Enemy(2, true, "Zombear"));
            this.enemyData.Add(new Enemy(3, true, "Zombear"));
            this.enemyData.Add(new Enemy(4, true, "Zombear"));
            this.enemyData.Add(new Enemy(5, true, "Zombear"));
            this.enemyData.Add(new Enemy(6, true, "Hellephant"));
            this.enemyData.Add(new Enemy(7, true, "Hellephant"));
            this.enemyData.Add(new Enemy(8, true, "Hellephant"));
            this.enemyData.Add(new Enemy(9, true, "Hellephant"));
            this.enemyData.Add(new Enemy(10,false, "Hydreigon"));
        }else if(currentIndexQuest==3){
            this.enemyCount = 3;
            this.enemyData.Add(new Enemy(0, true, "krookodile"));
            this.enemyData.Add(new Enemy(1, true, "Tyranitar"));
            this.enemyData.Add(new Enemy(2, true, "Hydreigon"));
            this.enemyData.Add(new Enemy(3, false, "Zoroark"));
            this.enemyData.Add(new Enemy(4, false, "Gengar"));
        }
    }
}