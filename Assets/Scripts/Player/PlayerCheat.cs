using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCheat : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private Text message;
    private GameObject player;
    private PlayerPet playerPet;
    private PetHealth petHealth;
    public GameManager gameManager;
    public InputField cheatInput;
    public Button applyCheat;
    private string cheatCode;
    private int indexPetCur;

    void Start() {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        message = GameObject.Find("Message").GetComponent<Text>();
        message.text = "";
        Button btn = applyCheat.GetComponent<Button>();
        playerPet = player.GetComponent<PlayerPet>();
		btn.onClick.AddListener(ApplyCheat);
        cheatInput.onValueChanged.AddListener(ValueCheatChangeCheck);
    }

    public void ValueCheatChangeCheck(string cheat)
    {
        cheatCode = cheat;
    }

    public void ApplyCheat()
    {
        if(cheatCode == "NoDamage") {
            NoDamage();
        } else if(cheatCode == "HitKill") {
            HitKill();
        } else if(cheatCode == "Motherlode") {
            Motherlode();
        } else if(cheatCode == "DoubleSpeed") {
            DoubleSpeed();
        } else if(cheatCode == "FullHp") {
            FullHp();
        } else if(cheatCode == "KillPet") {
            KillPet();
        } else {
            message.text = "Why you want to cheat?";
        }
    }

    public void closeCheatMenu()
    {
        gameManager.closeCheatMenu();
    }

    public void NoDamage()
    {
        playerHealth.ApplyNoDamageCheat();
        message.text = "No Damage Cheat Activated";
    }

    public void HitKill() {
        GameStates.setOneHitKillActive(true);
        message.text = "One Hit Kill Cheat Activated";
    }

    public void Motherlode()
    {
        GameStates.setPoin(999999);
        message.text = "Motherlode Cheat Activated";
    }

    public void DoubleSpeed()
    {
        playerMovement.ApplyDoubleSpeedCheat();
        message.text = "Double Speed Cheat Activated";
    }

    public void FullHp() {
        GameStates.setFullHPPetActive(true);
        message.text = "Full HP Cheat Activated";
    }


    public void KillPet() {
        indexPetCur = GameStates.getCurrIndexPet();
        if(indexPetCur == -1) {
            message.text = "You don't have pet";
        } else {
            GameStates.setPetData(new PetData(false, 0, new Vector3(0f, 0f, 0f), new Quaternion()), indexPetCur);
            GameStates.setCurrIndexPet(-1);
            playerPet.changePet(-1);
            message.text = "Kill Pet Cheat Activated";
        }
    }
}
