using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private int id;
    // Transform player;
    // PlayerHealth playerHealth;
    Rigidbody enemyRigidBody;
    // EnemyHealth enemyHealth;
    NavMeshAgent nav;

    public static bool isEnableEnemyMoveToPlayer;

    private Vector3 setEnemyCurrentPost(Vector3 updatedPosition){
        return transform.position = updatedPosition;
    }

    private Vector3 getEnemyCurrentPos(){
        return transform.position;
    }

    private void Awake ()
    {
        EnemyMovement.isEnableEnemyMoveToPlayer = true;
        nav = GetComponent<NavMeshAgent> ();
        this.id = IncGameState.maxId;
        nav.enabled = true;
        this.setEnemyCurrentPost(GameStates.getEnemyCoordinat(this.id));
        transform.rotation = GameStates.getEnemyRotation(this.id);
    }

    void Update () {
        if (GameStates.getHealthEnemy(this.id) > 0 && GameStates.getCurrHealth() > 0) {
            nav.SetDestination(GameStates.getCurrCoordinat()); 
            // Debug.Log("Enemy " + this.id + " to :" + GameStates.getCurrCoordinat());
            transform.LookAt(GameStates.getCurrCoordinat());
            GameStates.setEnemyRotation(transform.rotation, this.id);
            GameStates.setEnemyCoordinat(this.getEnemyCurrentPos(), this.id);
            EnemyMovement.isEnableEnemyMoveToPlayer = true;

        } else {    // when enemy's health = 0 (dead) or player's health = 0 (dead)
            EnemyMovement.isEnableEnemyMoveToPlayer = false;
        }
        nav.enabled = EnemyMovement.isEnableEnemyMoveToPlayer;
    }
}
