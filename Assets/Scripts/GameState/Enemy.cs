using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Enemy
{
    public int id;
    public bool isActive;
    public int enemyHealth;
    public Vector3 coordinat;
    private String enemyName;
    public Quaternion currentRotation;
    public Enemy(int currentId, bool isActive, string type){
        this.isActive = isActive;
        this.id = currentId;
        this.currentRotation = new Quaternion(0f, 0.90631f, 0f, 0.42262f);

        if(this.id == 0){
            this.coordinat = new Vector3(2f, 0f, 5f);
        }
        else if(this.id == 1){
            this.coordinat = new Vector3(-1.98f, 0f, 12.81f);
        }
        else if(this.id==2){
            this.coordinat = new Vector3(-8.80f, 0f, 0.53f);
        }
        else if(this.id==3){
            this.coordinat = new Vector3(10.69f, 0f, -9.06f);
        }
        else if(this.id==4){
            this.coordinat = new Vector3(15.84f, 0f, 4.68f);
        }
        else if(this.id==5){
            this.coordinat = new Vector3(-8.68f, 0f, 7.21f);
        }
        else if(this.id==6){
            this.coordinat = new Vector3(1.00f, 0f, 14.35f);
        }
        else if(this.id==7){
            this.coordinat = new Vector3(2.00f, 0f, -10.35f);
        }
        else if(this.id==8){
            this.coordinat = new Vector3(-5.00f, 0f, -5.35f);
        }
        else if(this.id==9){
            this.coordinat = new Vector3(5.00f, 0f, -6.35f);
        }
        else if(this.id==10){
            this.coordinat = new Vector3(-7.00f, 0f, 13.35f);
        }

        if(type=="Zombunny"){
            this.enemyHealth = 100;
        }
        else if(type=="Zombear"){
            this.enemyHealth = 200;
        }
        else if(type=="Hellephant"){
            this.enemyHealth = 300;
        }
        else if(type=="krookodile"){
            this.enemyHealth = 400;
        }
        else if(type=="Tyranitar"){
            this.enemyHealth = 700;
        }
        else if(type=="Hydreigon"){
            this.enemyHealth = 500;
        }
        else if(type=="Zoroark"){
            this.enemyHealth = 400;
        }
        else{
            this.enemyHealth = 1000;
        }

        this.enemyName = type;
    }

    public String getEnemyName(){
        return this.enemyName;
    }
}
