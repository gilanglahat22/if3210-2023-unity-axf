using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData
{
    public bool isExist;
    public int level;
    public int damage;

    public WeaponData(){
        this.isExist = false;
        this.level = 0;
        this.damage = 100;
    }

    public WeaponData(bool isExistUpdated, int levelUpdated, int damageUpdated){
        this.isExist = isExistUpdated;
        this.level = levelUpdated;
        this.damage = damageUpdated;
    }
}
