using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPet : MonoBehaviour
{
    int currentPetIndex;     // -1 = no pet, 0 = healer, 1 = attacker, 2 = buff
    public GameObject[] pets;

    void Awake() {
        currentPetIndex = GameStates.getCurrIndexPet();
        summonPet(currentPetIndex);
        // Debug.Log(currentPetIndex);
    }

    public void summonPet(int petIdx) {
        if (petIdx == -1) {
            for (int i = 0; i < pets.Length; i++) {
                pets[i].SetActive(false);
            }
            return;
        }
        for (int i = 0; i < pets.Length; i++) {
            if (i == petIdx) {
                if(GameStates.getPetDataIsExist(i)) {
                    pets[i].SetActive(true);
                } else {
                    pets[i].SetActive(false);
                }
            } else {
                pets[i].SetActive(false);
            }
        }
    }

    public void changePet(int newPetIdx) {
        currentPetIndex = newPetIdx;
        GameStates.setCurrIndexPet(newPetIdx);
        summonPet(newPetIdx);
    }
}
