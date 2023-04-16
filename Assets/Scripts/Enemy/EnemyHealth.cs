using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int id;
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int killValue;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        this.id = IncGameState.maxId;
        currentHealth = GameStates.getHealthEnemy(this.id);
        enemyAudio.volume = AudioSettings.getVolumeSound();
        enemyAudio.mute = !AudioSettings.getIsOnSound();
    }


    void Update ()
    {
        if (isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;
        enemyAudio.mute = !AudioSettings.getIsOnSound();
        enemyAudio.volume = AudioSettings.getVolumeSound();
        enemyAudio.Play ();
        if(GameStates.getOneHitKillActive()) {
            amount = startingHealth;
        }
        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        // Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("FinalBoss")) {
                BossDeath();
            }
            else {
                Death ();
            }
            GameStates.setHealthEnemy(0, this.id);
        }else{
            GameStates.setHealthEnemy(currentHealth, this.id);
        }
    }

    void BossDeath ()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger ("Dead");
        enemyAudio.mute = !AudioSettings.getIsOnSound();
        enemyAudio.volume = AudioSettings.getVolumeSound();
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
        GameStates.setEnemyCount(GameStates.getEnemyCount() -1);
        GameStates.setPoin(GameStates.getCurrentPoin() + killValue);
        GameStates.setIsBossDefeated(true);
        GameStates.setActiveEnemy(false, this.id);
    }

    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
        anim.SetTrigger ("Dead");
        enemyAudio.mute = !AudioSettings.getIsOnSound();
        enemyAudio.volume = AudioSettings.getVolumeSound();
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
        GameStates.setEnemyCount(GameStates.getEnemyCount() -1);
        GameStates.setPoin(GameStates.getCurrentPoin() + killValue);
        GameStates.setActiveEnemy(false, this.id);
        StartSinking();
    }


    public void StartSinking ()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent<Rigidbody> ().isKinematic = true;
        isSinking = true;
        Destroy (gameObject, 2f);
        // Debug.Log("Enemy Sinking");
    }
}
