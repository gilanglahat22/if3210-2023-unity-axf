using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingToLeaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            GameStates.addLeaderboard(GameStates.getCurrentPlayerName(), GameStates.getCurrDuration());
            SceneManager.LoadScene("Leaderboard");
        }
    }
}
