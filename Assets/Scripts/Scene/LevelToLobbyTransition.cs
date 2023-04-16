using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelToLobbyTransition : MonoBehaviour 
{
    public string nextSceneName;
    public string portalLevel;
    private bool isPlayerInRange = false;
    public GameObject messagePrompt;
    public GameObject lockLevelPrompt; 
    public GameObject exitPrompt;
    PlayerData playerData = new PlayerData();

    // public bool isLevel1completed = false;
    // public bool isLevel2completed = false;
    // public bool isLevel3completed = false;
    // public bool isLevel4completed = false;

    void Start() {
        messagePrompt.SetActive(false);
        lockLevelPrompt.SetActive(false);
    }

    void Update() {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && GameManager.isLevel1completed) {
            SceneManager.LoadScene(nextSceneName);
            GameStates.setCurrCoordinat(new Vector3(-14f, 0f, -6f));
            // GameStates.setCameraPosition(new Vector3(-14f, 0f, -6f));
        }
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !GameManager.isLevel1completed) {
            SceneManager.LoadScene("PostLevel1Scene");
            GameManager.isLevel1completed = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && portalLevel == "1" && GameStates.getEnemyCount() == 0) {
            isPlayerInRange = true;
            messagePrompt.SetActive(true);
            exitPrompt.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player") && portalLevel == "2" && GameStates.getEnemyCount() == 0) {
            GameManager.isLevel2completed = true;
            isPlayerInRange = true;
            messagePrompt.SetActive(true);
            exitPrompt.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player") && portalLevel == "3" && GameStates.getEnemyCount() == 0) {
            GameManager.isLevel3completed = true;
            isPlayerInRange = true;
            messagePrompt.SetActive(true);
            exitPrompt.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player") && portalLevel == "4" && GameStates.getEnemyCount() == 0) {
            if (!GameStates.getIsBossDefeated()) {
                GameStates.setSpawnBossIsActive(true);
            }
            else {
                GameManager.isLevel4completed = true;
                isPlayerInRange = true;
                messagePrompt.SetActive(true);
                exitPrompt.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Player") && GameStates.getEnemyCount() != 0){
            lockLevelPrompt.SetActive(true);
            isPlayerInRange = false;
            exitPrompt.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player") && GameStates.getEnemyCount() != 0) {
            isPlayerInRange = false;
            lockLevelPrompt.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player") && GameStates.getEnemyCount() == 0) {
            isPlayerInRange = false;
            messagePrompt.SetActive(false);
            exitPrompt.SetActive(true);
        }
    }
}
