using UnityEngine;
using TMPro;

public class EnemyCountManager : MonoBehaviour
{
    // public static int enemyCount;
    public GameObject questFinish;
    public GameObject exitPrompt;

    private TMPro.TextMeshProUGUI enemyCounter;
    private bool isEnemyWaveCompleted = true;

    void Awake ()
    {
        enemyCounter = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update ()
    {
        enemyCounter.text = "Enemy Remaining: " + GameStates.getEnemyCount();
        if (GameStates.getEnemyCount() == 0 && isEnemyWaveCompleted)
        {   
            exitPrompt.SetActive(true);
            questFinish.SetActive(true);
            
            int bonusCourage = 0;
            if (!GameManager.isLevel1completed) 
            {
                bonusCourage = 100;
            }
            else if (!GameManager.isLevel2completed) 
            {
                bonusCourage = 200;
            }
            else if (!GameManager.isLevel3completed)  
            {
                bonusCourage = 300;
            }
            else if (!GameManager.isLevel4completed && GameStates.getIsBossDefeated()) 
            {
                bonusCourage = 400;
            }
            
            GameStates.setPoin(GameStates.getCurrentPoin() + bonusCourage);

            isEnemyWaveCompleted = false;
        }
    }

}