using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetHealth : MonoBehaviour
{
    public int startingHealth = 50;
    public int currentHealth;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public bool isTakeDamaged = false;

    GameObject player;
    PetMovement petMovement;
    PetSkill petSkill;
    PlayerPet playerPet;
    public AudioClip petDamagedSound;
    AudioSource audioSource;
    private bool isFullHPPetActive;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPet = player.GetComponent<PlayerPet>();
        petMovement = GetComponent<PetMovement>();
        petSkill = GetComponent<PetSkill>();

        int petId = GameStates.getCurrIndexPet();
        currentHealth = petId != -1 ? GameStates.getPetHealth(petId) : 0;
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {}

    public void TakeDamage(int amount) {
        isTakeDamaged = true;
        audioSource.clip = petDamagedSound;
        audioSource.Play();       
         
        if(!GameStates.getFullHPPetActive()) {
            currentHealth -= amount;
            if (currentHealth <= 0) {
                GameStates.setPetHealth(0, GameStates.getCurrIndexPet());
                Death();
            }else{
                GameStates.setPetHealth(currentHealth, GameStates.getCurrIndexPet());
            }
        }
    }

    void Death() {
        playerPet.changePet(-1);
        petSkill.resetSkill();
    }
}