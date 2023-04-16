using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public GameObject backgroundMusicNormalEnemy;
    public GameObject backgroundMusicBoss;

    void Update()
    {
        if (GameStates.getEnemyCount() != 0 && !GameStates.getSpawnBossIsActive()) {
            backgroundMusicNormalEnemy.SetActive(true);
            backgroundMusicBoss.SetActive(false);
        }

        else if (GameStates.getIsBossDefeated()) {
            backgroundMusicNormalEnemy.SetActive(true);
            backgroundMusicBoss.SetActive(false);
        }

        else if (GameStates.getSpawnBossIsActive()) {
            backgroundMusicNormalEnemy.SetActive(false);
            backgroundMusicBoss.SetActive(true);
        }
        // Debug.Log(backgroundMusicNormalEnemy.volume);
    }
}
