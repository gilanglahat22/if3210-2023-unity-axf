using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyToLevelTransition : MonoBehaviour 
{
    public string nextSceneName;
    public string portalLevel;
    private bool isPlayerInRange = false;
    public GameObject messagePrompt;
    public GameObject lockLevelPrompt; 

    // public bool isLevel1completed = false;
    // public bool isLevel2completed = false;
    // public bool isLevel3completed = false;
    // public bool isLevel4completed = false;

    void Start() {
        messagePrompt.SetActive(false);
        lockLevelPrompt.SetActive(false);
    }

    void Update() {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene(nextSceneName);
            GameStates.setCurrCoordinat(new Vector3(0f, 0f, 0f));
            GameStates.setCameraPosition(new Vector3(1f, 15f, -22f));
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && portalLevel == "1" && GameManager.isLevel1completed == true ) {
            isPlayerInRange = true;
            messagePrompt.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Player") && portalLevel == "2" && GameManager.isLevel1completed == true) {
            isPlayerInRange = true;
            messagePrompt.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Player") && portalLevel == "3" && GameManager.isLevel1completed == true && GameManager.isLevel2completed == true) {
            isPlayerInRange = true;
            messagePrompt.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Player") && portalLevel == "4" && GameManager.isLevel1completed == true && GameManager.isLevel2completed == true && GameManager.isLevel3completed == true) {
            isPlayerInRange = true;
            messagePrompt.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Player") && portalLevel == "5" && GameManager.isLevel1completed == true && GameManager.isLevel2completed == true && GameManager.isLevel3completed == true && GameManager.isLevel4completed == true) {
            isPlayerInRange = true;
            messagePrompt.SetActive(true);
        }
        else {
            lockLevelPrompt.SetActive(true);
            isPlayerInRange = false;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player") ) {
            isPlayerInRange = false;
            messagePrompt.SetActive(false);
            lockLevelPrompt.SetActive(false);
        }
    }
}
