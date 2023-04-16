using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGame : MonoBehaviour
{
    public string nextSceneName;

    void OnEnable()
    {
        //this will be used to load opening scene 2 right after opening scene 1
        if (nextSceneName == "Lobby") {
            SceneManager.LoadScene(nextSceneName);
            GameStates.setCurrCoordinat(new Vector3(-14f, 0f, -6f));
        }
        else {
            SceneManager.LoadScene(nextSceneName);
            GameStates.setCurrCoordinat(new Vector3(0f, 0f, 0f));
        }
    }
}