using UnityEngine;
 
public class EnemyManager : MonoBehaviour
{
        public GameObject[] enemies;

    void Start ()
    {
        // Spawn Enemy
        if (!GameStates.getIsMiniBossSpawn()) {
                GameStates.setEnemyCount(enemies.Length);
                for (int i = 0; i < enemies.Length; i++){
                        IncGameState.maxId = i;
                        GameStates.setActiveEnemy(true, i);
                        Instantiate(enemies[i], GameStates.getEnemyCoordinat(i), GameStates.getEnemyRotation(i));
                }
        }
        // Spawn Mini Boss
        else if (GameStates.getIsMiniBossSpawn() && !GameStates.getSpawnBossIsActive()) {
                GameStates.setEnemyCount(enemies.Length + 1);
                if(GameStates.getCurrentIndexQuest() >=0 && GameStates.getCurrentIndexQuest() <= 2){    // If Current Quest : 0, 1, 2
                        IncGameState.maxId = 10;
                        GameStates.setActiveEnemy(true, 10);
                        Instantiate(enemies[0], GameStates.getEnemyCoordinat(10), GameStates.getEnemyRotation(10));
                }else{  // If Current Quest : 3 (last quest)
                        IncGameState.maxId = 3;
                        GameStates.setActiveEnemy(true, 3);
                        Instantiate(enemies[0], GameStates.getEnemyCoordinat(3), GameStates.getEnemyRotation(3));
                }
                GameStates.setIsMiniBossSpawn(false);
        }
        // Spawn Final Boss
        else if(GameStates.getSpawnBossIsActive() && !GameStates.getIsBossDefeated()){
                GameStates.setActiveEnemy(true, 4);
                IncGameState.maxId = 4;
                Instantiate(enemies[0], GameStates.getEnemyCoordinat(4), GameStates.getEnemyRotation(4));
        }
    }
}
