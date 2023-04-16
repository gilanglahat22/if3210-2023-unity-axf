using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossManager : MonoBehaviour
{
    public GameObject miniBossManager;
    // public static bool isMiniBossSpawn = false;
    private bool isShown = false;

    void Update()
    {
        // spawn mini boss
        if (GameStates.getEnemyCount() == 1 && !GameStates.getIsMiniBossSpawn() && !isShown)
        {
            miniBossManager.SetActive(true);
            GameStates.setIsMiniBossSpawn(true);
            // isMiniBossSpawn = true;
            isShown = true;
        }
        
    }
}