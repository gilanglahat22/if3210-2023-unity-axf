using UnityEngine;
using System.Collections;
 
public class EnemyAttack : MonoBehaviour
{
    private int id;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
 
    PlayerPet playerPet;
    Animator anim;
    GameObject player;
    GameObject pet;
    bool playerInRange;
    bool petInRange;
    float timer;
 
 
    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerPet = player.GetComponent<PlayerPet>();

        this.id = IncGameState.maxId;
        anim = GetComponent <Animator> ();
        setCurrentPet();
    }
 
    public void setCurrentPet() {
        // Debug.Log("Debug current pet: "+GameStates.getCurrIndexPet());
        // if (GameStates.getCurrIndexPet() != -1) {
        //     Debug.Log("Ini debug enemy attack "+playerPet.pets[GameStates.getCurrIndexPet()]);
        //     pet = playerPet.pets[GameStates.getCurrIndexPet()];
        // } else {
        //     Debug.Log("Ini debug enemy attack "+playerPet.pets[GameStates.getCurrIndexPet()]);
        //     pet = null;
        // }
    }
 
    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter (Collider other)
    {
        //check if it is player or a pet that enters the trigger
        if(other.gameObject == player  && other.isTrigger == false)
        {
            playerInRange = true;
        }
        if(other.gameObject.tag == "Pet" && other.isTrigger == false)
        {
            petInRange = true;
        }
    }
 
    //Callback jika ada object yang keluar dari trigger
    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
        if(other.gameObject.tag == "Pet")
        {
            petInRange = false;
        }
    }
 
 
    void Update ()
    {
        timer += Time.deltaTime;
 
        if(timer >= timeBetweenAttacks && (playerInRange) && GameStates.getHealthEnemy(this.id)> 0)
        {
            AttackPlayer ();
        }
        if(timer >= timeBetweenAttacks && (petInRange) && GameStates.getHealthEnemy(this.id)> 0)
        {
            AttackPet();
            setCurrentPet();
        }
 
        if(GameStates.getCurrHealth()<=0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }
 
 
    void AttackPlayer ()
    {
        //Reset timer
        timer = 0f;
        if(GameStates.getCurrHealth() > 0)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    void AttackPet()
    {
        //Reset timer
        timer = 0f;
        if(GameStates.getCurrIndexPet() != -1 && GameStates.getPetHealth(GameStates.getCurrIndexPet()) > 0)
        {
            pet.GetComponent<PetHealth>().TakeDamage(attackDamage);
        }
    }
}