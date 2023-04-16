using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetSkill : MonoBehaviour
{
    public int healAmount = 20;
    public Slider healthSlider;
    public int attackAmount = 100;
    public float speedBuff = 10f;
    public int atkBuff = 10;
    Animator anim;
    public AudioClip skillSound;
    AudioSource audioSource;

    private GameObject[] enemies;
    GameObject player;
    GameObject closestEnemy = null;
    private int petIndex;

    public float skillTime = 10f;
    float timer;

    void Start() {
        // get player's pet index
        player = GameObject.FindGameObjectWithTag("Player");
        petIndex = GameStates.getCurrIndexPet();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = skillSound;
        anim = GetComponent<Animator>();
    }

    void Update() {
        timer += Time.deltaTime;
        if (petIndex == 0 && timer > skillTime) {        // healer pet
            healPlayer();
        } else if (petIndex == 1 && timer > 2f) { // attacker pet
            attack();
        } else if (petIndex == 2) { // buff pet
            buffPlayer();
        }
    }

    void healPlayer() {
        timer = 0f;

        anim.SetBool("IsAttack", true);
        audioSource.Play();

        GameStates.setCurrHealth(GameStates.getCurrHealth() + healAmount);
        healthSlider.value = GameStates.getCurrHealth();

        anim.SetBool("IsAttack", false);
    }

    public GameObject getClosestEnemy(Vector3 position) {
        // list all object with tag=Enemy to enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject closeEnemy = null;

        foreach (GameObject enemy in enemies) {
            float currentDistance;
            currentDistance = Vector3.Distance(position, enemy.transform.position);
            if (currentDistance < closestDistance) {
                closestDistance = currentDistance;
                closeEnemy = enemy;
            }
        }

        if (closeEnemy == null) // if no more enemy, try find final boss
        {
            GameObject finalBoss = GameObject.FindGameObjectWithTag("FinalBoss");
            if (finalBoss != null) return finalBoss;    // if there's final boss, return it
            else return null;                           // if there's no final boss, return null
        }

        return closeEnemy;
    }

    void attack() {
        timer = 0f;
        // Debug.Log("Attack enemy");
        closestEnemy = getClosestEnemy(transform.position);
        if (closestEnemy == null) return;

        anim.SetBool("IsAttack", true);
        closestEnemy.GetComponent<EnemyHealth>().TakeDamage(attackAmount, closestEnemy.transform.position);
        audioSource.Play();
        anim.SetBool("IsAttack", false);
    }

    void buffPlayer() {
        // buff player's speed
        GameStates.setSpeed(speedBuff);

        // buff player's damage
        GameStates.setDamage(atkBuff);
    }

    public void resetSkill() {
        // reset player's speed
        GameStates.setSpeed(6f);

        // reset player's damage
        GameStates.setDamage(10);
    }
}
