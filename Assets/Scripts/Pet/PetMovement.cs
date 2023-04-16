using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    NavMeshAgent nav;
    Vector3 target;
    GameObject player;
    PlayerPet playerPet;
    PetSkill petSkill;
    Animator anim;

    private void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPet = player.GetComponent<PlayerPet>();
        petSkill = GetComponent<PetSkill>();
        nav = GetComponent<NavMeshAgent>();
        if (GameStates.getCurrIndexPet() != 2) anim = GetComponent<Animator>();
    }

    void Awake(){
        transform.position = GameStates.getPetCoordinate(GameStates.getCurrIndexPet());
        transform.rotation = GameStates.getPetRotation(GameStates.getCurrIndexPet());
    }

    void Update () {
        if (GameStates.getCurrIndexPet() == 1)
        {
            GameObject enemy = petSkill.getClosestEnemy(transform.position);
            target = enemy.transform.position;
            nav.SetDestination(target);
            transform.LookAt(target);
            GameStates.setPetCoordinate(transform.position, GameStates.getCurrIndexPet());
        }
        else
        {
            target = GameStates.getCurrCoordinat();
            nav.SetDestination(target);
            transform.LookAt(target);
            GameStates.setPetCoordinate(transform.position, GameStates.getCurrIndexPet());
        }

        if (GameStates.getCurrIndexPet() != 2)
        {
            bool walking = Vector3.Distance(transform.position, target) > 1f;
            // Debug.Log("walking value = " + walking);
            anim.SetBool("IsWalking", walking);      // walking animation
        }
    }
}
