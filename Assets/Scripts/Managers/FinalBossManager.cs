using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossManager : MonoBehaviour
{
    public GameObject finalBossManager;
    public GameObject bossDefeatedPrompt;
    public GameObject questFinishPrompt;
    public GameObject exitPrompt;
    public GameObject killBossPrompt;
    private bool isShown = false;

    void Update()
    {
        // spawn final boss
        if (GameStates.getSpawnBossIsActive() && !GameStates.getIsBossDefeated())
        {
            finalBossManager.SetActive(true);
            questFinishPrompt.SetActive(false);
            exitPrompt.SetActive(false);
            killBossPrompt.SetActive(true);
            GameStates.setEnemyCount(1);
        }

        // final boss defeated
        if (GameStates.getIsBossDefeated() && !isShown)
        {
            bossDefeatedPrompt.SetActive(true);
            killBossPrompt.SetActive(false);
            exitPrompt.SetActive(true);
            GameStates.setSpawnBossIsActive(false);
            isShown = true;
        }
    }
}
