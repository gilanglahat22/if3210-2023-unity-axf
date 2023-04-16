using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject[] weapons;
    public int currentWeaponIndex = 0;
    public GameObject bowForceSlider;

    void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == currentWeaponIndex)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
        showHideBowForceSlider();
    }

    void Update(){
        // if(weapons[1].GetComponent<ShotgunShoot>() != null) GameStates.setWeaponData(true,2);
        // if(weapons[2].GetComponent<SwordShoot>() != null) GameStates.setWeaponData(true,3);
        // if(weapons[3].GetComponent<BowShoot>() != null) GameStates.setWeaponData(true,4);
    }

    void showHideBowForceSlider()
    {
        if (currentWeaponIndex == 3)
        {
            bowForceSlider.SetActive(true);
        }
        else
        {
            bowForceSlider.SetActive(false);
        }
    }

    public void ChangeWeapon(int _currentWeaponIndex)
    {
        // Debug.Log(GameStates.getListWeaponInventory());

        if (GameStates.getIsExistWeapon(_currentWeaponIndex) == false)
        {
            return;
        }
        GameStates.setIndexCurrentWeapon(_currentWeaponIndex);
        weapons[currentWeaponIndex].SetActive(false);
        //GameStates.setIsExistWeapon(false, currentWeaponIndex);
        currentWeaponIndex = _currentWeaponIndex;
        weapons[currentWeaponIndex].SetActive(true);
        //GameStates.setIsExistWeapon(true, currentWeaponIndex);
        showHideBowForceSlider();
    }

    public void Shoot()
    {
        if(!PlayerMovement.isDead){
            // in the game object, there is a script "DefaultWeaponShoot" that has a method "Shoot"
            if (currentWeaponIndex == 0)
            {
                weapons[currentWeaponIndex].GetComponent<DefaultWeaponShoot>().Shoot();
            }
            else if (currentWeaponIndex == 1)
            {
                weapons[currentWeaponIndex].GetComponent<ShotgunShoot>().Shoot();
            }
            else if (currentWeaponIndex == 2)
            {
                weapons[currentWeaponIndex].GetComponent<SwordShoot>().Shoot();
            }
            else if (currentWeaponIndex == 3)
            {
                weapons[currentWeaponIndex].GetComponent<BowShoot>().Shoot();
            }
        }
    }

}
