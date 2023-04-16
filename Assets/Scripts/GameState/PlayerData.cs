using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string name;
    public double duration;
    public int health;
    public float speed;
    public int damage;
    public int indexCurrentWeapon;
    public int poin;
    public List<int> poinTimestamp;
    public int indexPet;
    public int currindexQuest;
    public Vector3 currentCoordinat;
    public Quaternion currentRotation;
    public List<WeaponData> weaponInventory;
    public List<PetData> petInventory;
    public Vector3 mainCameraPosition;
    public PlayerData(){
        this.name = "PLAYER";
        this.duration = 0.0;
        this.health = 100;
        this.speed = 6f;
        this.damage = 0;
        this.indexCurrentWeapon = 0;
        this.poin = 0;
        this.poinTimestamp = new List<int>();
        this.poinTimestamp.Add(0);
        this.poinTimestamp.Add(0);
        this.poinTimestamp.Add(0);
        this.poinTimestamp.Add(0);
        this.currindexQuest = 0;
        this.indexPet = -1;
        this.currentCoordinat = new Vector3(0f, 0f, 0f);
        this.currentRotation = new Quaternion();
        this.mainCameraPosition = new Vector3(1f, 15f, -22f);
        this.weaponInventory = new List<WeaponData>();
        this.weaponInventory.Add(new WeaponData(true, 1, 20)); 
        this.weaponInventory.Add(new WeaponData(false, 1, 25));
        this.weaponInventory.Add(new WeaponData(false, 1, 50));
        this.weaponInventory.Add(new WeaponData(false, 1, 35));
        this.petInventory = new List<PetData>();
        this.petInventory.Add(new PetData(true, 50, new Vector3(2f, 0f, 0f), new Quaternion()));
        this.petInventory.Add(new PetData());
        this.petInventory.Add(new PetData());
    }
}
