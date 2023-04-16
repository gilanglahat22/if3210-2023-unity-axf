using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShopkeeper : MonoBehaviour
{

    private Text points;
    private Text error;
    private Text shotgunLevelText;
    private Text swordLevelText;
    private Text bowLevelText;
    public Button chickenPetButton;
    public Button bearPetButton;
    public Button dronePetButton;
    public Button ShotgunWeaponButton;
    public Button SwordWeaponButton;
    public Button BowWeaponButton;
    private List<WeaponData> weaponInventory = new List<WeaponData>();

    void Start() {
        points = GameObject.Find("Points").GetComponent<Text>();
        error = GameObject.Find("Error").GetComponent<Text>();
        shotgunLevelText = GameObject.Find("ShotgunLevelText").GetComponent<Text>();
        swordLevelText = GameObject.Find("SwordLevelText").GetComponent<Text>();
        bowLevelText = GameObject.Find("BowLevelText").GetComponent<Text>();
        shotgunLevelText.text = "";
        swordLevelText.text = "";
        bowLevelText.text = "";

        points.text = "Your points: " + GameStates.getCurrentPoin().ToString();
        
        weaponInventory = GameStates.getListWeaponInventory(); 

        chickenPetButton.onClick.AddListener(ChickenPetButton);
        bearPetButton.onClick.AddListener(BearPetButton);
        dronePetButton.onClick.AddListener(DronePetButton);
        ShotgunWeaponButton.onClick.AddListener(BuyShotgunWeapon);
        SwordWeaponButton.onClick.AddListener(BuySwordWeapon);
        BowWeaponButton.onClick.AddListener(BuyBowWeapon);
        error.text = "";
    }

    void Update() {
        points.text = "Your points: " + GameStates.getCurrentPoin().ToString();
    }

    public void UnlimitedMoney() {
        GameStates.setPoin(999999);
    }

    public void ChickenPetButton() {
        // Debug.Log("Chicken Pet");
        if (GameStates.getCurrentPoin() >= 100 && !GameStates.getPetDataIsExist(0)) {
            GameStates.setPoin(GameStates.getCurrentPoin() - 100);
            // Debug.Log("Success buy Chicken pet");
            GameStates.setPetData(new PetData(true, 50, new Vector3(2f, 0f, 0f), new Quaternion()), 0);
            GameStates.setCurrIndexPet(0);
            error.text = "Success buy Chicken pet";
        } else if (GameStates.getPetDataIsExist(0)) {
            GameStates.setCurrIndexPet(0);
            error.text = "You equip pet tp Chicken";
        } else {
            error.text = "You don't have enough points";
        }
    }

    public void BearPetButton() {
        // Debug.Log("Bear Pet");
        if (GameStates.getCurrentPoin() >= 100 && !GameStates.getPetDataIsExist(1)) {
            GameStates.setPoin(GameStates.getCurrentPoin() - 100);
            GameStates.setPetData(new PetData(true, 50, new Vector3(2f, 0f, 0f), new Quaternion()), 1);
            GameStates.setCurrIndexPet(1);
            error.text = "Success buy Bear pet";
        } else if (GameStates.getPetDataIsExist(1)) {
            GameStates.setCurrIndexPet(1);
            error.text = "You equip pet tp Bear";
        } else {
            error.text = "You don't have enough points";
        }
    }

    public void DronePetButton() {
        // Debug.Log("Drone Pet");
        if (GameStates.getCurrentPoin() >= 100 && !GameStates.getPetDataIsExist(2)) {
            GameStates.setPoin(GameStates.getCurrentPoin() - 100);
            GameStates.setPetData(new PetData(true, 50, new Vector3(2f, 0f, 0f), new Quaternion()), 2);
            GameStates.setCurrIndexPet(2);
            error.text = "Success buy Drone pet";
        } else if (GameStates.getPetDataIsExist(2)) {
            GameStates.setCurrIndexPet(2);
            error.text = "You equip pet tp Drone";
        } else {
            error.text = "You don't have enough points";
        }
    }

    public void BuyShotgunWeapon() {
        if (GameStates.getCurrentPoin() >= 100 && !weaponInventory[1].isExist) {
            GameStates.setPoin(GameStates.getCurrentPoin() - 100);
            GameStates.setIsExistWeapon(true, 1);
            error.text = "Success buy shotgun weapon";
            shotgunLevelText.text = "Level: " + GameStates.getLevelWeapon(1).ToString() + " Damage: " + GameStates.getDamageWeapon(1).ToString();
        } else if (GameStates.getCurrentPoin() >= 100 && weaponInventory[1].isExist) {
            if(GameStates.getLevelWeapon(1) == 5) {
                error.text = "You already have max level";
            } else {
                GameStates.setPoin(GameStates.getCurrentPoin() - 100);
                GameStates.setWeaponData(true, GameStates.getLevelWeapon(1) + 1, GameStates.getDamageWeapon(1) + 10, 1);
                error.text = "Success upgrade shotgun weapon";
                shotgunLevelText.text = "Level: " + GameStates.getLevelWeapon(1).ToString() + " Damage: " + GameStates.getDamageWeapon(1).ToString();
            }
        } else {
            error.text = "You don't have enough points";
        }
    }

    public void BuySwordWeapon() {
        if (GameStates.getCurrentPoin() >= 100 && !weaponInventory[2].isExist) {
            GameStates.setPoin(GameStates.getCurrentPoin() - 100);
            GameStates.setIsExistWeapon(true, 2);
            error.text = "Success buy sword weapon";
            swordLevelText.text = "Level: " + GameStates.getLevelWeapon(2).ToString() + " Damage: " + GameStates.getDamageWeapon(2).ToString();
        } else if (GameStates.getCurrentPoin() >= 100 && weaponInventory[2].isExist) {
            if(GameStates.getLevelWeapon(2) == 5) {
                error.text = "You already have max level";
            } else {
                GameStates.setPoin(GameStates.getCurrentPoin() - 100);
                GameStates.setWeaponData(true, GameStates.getLevelWeapon(2) + 1, GameStates.getDamageWeapon(2) + 10, 2);
                error.text = "Success upgrade sword weapon";
                swordLevelText.text = "Level: " + GameStates.getLevelWeapon(2).ToString() + " Damage: " + GameStates.getDamageWeapon(2).ToString();
            }
        } else {
            error.text = "You don't have enough points";
        }
    }

    public void BuyBowWeapon() {
        if (GameStates.getCurrentPoin() >= 100 && !weaponInventory[3].isExist) {
            GameStates.setPoin(GameStates.getCurrentPoin() - 100);
            GameStates.setIsExistWeapon(true, 3);
            error.text = "Success buy bow weapon";
            bowLevelText.text = "Level: " + GameStates.getLevelWeapon(3).ToString() + " Damage: " + GameStates.getDamageWeapon(3).ToString();
        } else if (GameStates.getCurrentPoin() >= 100 && weaponInventory[3].isExist) {
            if(GameStates.getLevelWeapon(3) == 5) {
                error.text = "You already have max level";
            } else {
                GameStates.setPoin(GameStates.getCurrentPoin() - 100);
                GameStates.setWeaponData(true, GameStates.getLevelWeapon(3) + 1, GameStates.getDamageWeapon(3) + 10, 3);
                error.text = "Success upgrade bow weapon";
                bowLevelText.text = "Level: " + GameStates.getLevelWeapon(3).ToString() + " Damage: " + GameStates.getDamageWeapon(3).ToString();
            }
        } else {
            error.text = "You don't have enough points";
        }
    }
}
