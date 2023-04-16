using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PetData
{
    public bool isExist;
    public int hp;
    public Vector3 coordinat;
    public Quaternion currentRotation;

    public PetData(){
        this.isExist = false;
        this.hp = 50;
        this.coordinat = new Vector3(2f, 0f, 0f);
        this.currentRotation = new Quaternion();
    }
    public PetData(bool isExistUpdated, int hpUpdated, Vector3 coordinateUpdated, Quaternion rotationUpdated){
        this.isExist = isExistUpdated;
        this.hp = hpUpdated;
        this.coordinat = coordinateUpdated;
        this.currentRotation = rotationUpdated;
    }
}
