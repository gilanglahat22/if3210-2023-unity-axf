using UnityEngine;
using UnityEngine.UI;
using System.Collections;
// using System.boolean;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    bool isDead;
    bool damaged;
    bool noDamageCheatActive;

    void Awake() {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAudio.mute = !AudioSettings.getIsOnSound();
        playerAudio.volume = AudioSettings.getVolumeSound();
        currentHealth = GameStates.getCurrHealth();
        // currentHealth = startingHealth;
    }


    void Update() {
        if (damaged) {
            damageImage.color = flashColour;
        } else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }


    public void TakeDamage(int amount) {
        if (noDamageCheatActive) {
            return;
        }
        damaged = true;
        currentHealth -= amount;
        // Debug.Log("Health player: " + currentHealth);
        playerAudio.mute = !AudioSettings.getIsOnSound();
        playerAudio.volume = AudioSettings.getVolumeSound();
        playerAudio.Play();
        if(!isDead){
            if(currentHealth > 0){
                healthSlider.value = currentHealth;
                GameStates.setCurrHealth(currentHealth);
            }else {
                currentHealth = 0;
                healthSlider.value = currentHealth;
                GameStates.setCurrHealth(currentHealth);
                Death();
            }
        }
    }


    void Death() {
        isDead = true;
        anim.SetTrigger("Die");
        playerAudio.mute = !AudioSettings.getIsOnSound();
        playerAudio.volume = AudioSettings.getVolumeSound();
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
    }

    public void RestartLevel () {
        SceneManager.LoadScene (0);
    }

    public void ApplyNoDamageCheat() {
        // HP dari player tidak akan berkurang jika diserang oleh mob selama 10 detik
        if (!noDamageCheatActive) {
            noDamageCheatActive = true;
        }
    }
}
