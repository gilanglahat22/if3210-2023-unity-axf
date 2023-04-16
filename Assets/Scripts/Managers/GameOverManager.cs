using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public Text timeText;
    public GameObject gameOverPopup;
    public PlayerHealth playerHealth;   
    public float restartDelay = 5f;
    public static bool isPauseElapsedTime;
    // Animator anim;                          
    float restartTimer;                    
    float delayDeath;

    void Awake()
    {
        GameOverManager.isPauseElapsedTime = false;
        restartTimer = 0f;
        delayDeath = 0f;
        gameOverPopup.SetActive(false);
        // anim = GetComponent<Animator>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }


    void Update()
    {
        // Debug.Log("ini di gameOver manager: "+ playerHealth.currentHealth);
        if (playerHealth.currentHealth <= 0)
        {
            GameOverManager.isPauseElapsedTime = true;
            PlayerMovement.isDead = true;
            EnemyMovement.isEnableEnemyMoveToPlayer = false;
            if(delayDeath>=4f){
                // Time.timeScale = 0f;
                gameOverPopup.SetActive(true);
                timeText.text = (5f-restartTimer).ToString("0.00");
                restartTimer += Time.deltaTime;
                if (restartTimer >= restartDelay)
                {
                    timeText.text = "0.00";
                    GameStates.setCurrHealth(100);
                    playerHealth.currentHealth = 100;
                    int tempIndexQuest = GameStates.getCurrentIndexQuest();
                    GameStates.resetEnemyData(tempIndexQuest);
                    restartTimer = 0f;
                    GameStates.resetGame();
                    SceneManager.LoadScene("Start_Game");
                }
            }
            delayDeath += Time.deltaTime;

            // anim.SetTrigger("GameOver");
        }else{
            gameOverPopup.SetActive(false);
        }
    }

    void OnDestroy(){
        Debug.Log("Scene ke "+ GameStates.getCurrentMainScene());
    }
    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m",Mathf.RoundToInt(enemyDistance));
//         anim.SetTrigger("Warning");
    }
}