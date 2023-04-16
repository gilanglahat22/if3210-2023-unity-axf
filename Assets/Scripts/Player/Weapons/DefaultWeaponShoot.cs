using UnityEngine;

public class DefaultWeaponShoot : MonoBehaviour
{
    private int damagePerShot =  GameStates.getDamageWeapon(0);            
    public float timeBetweenBullets = 0.15f;        
    public float range = 100f;   
    
    public GameObject gunBarrelEnd;
    public GameObject player;
    ParticleSystem gunParticles;
    LineRenderer gunLine;                           
    AudioSource gunAudio;                           
    Light gunLight;                                 
    float effectsDisplayTime = 0.2f; 

    float timer;                                    
    Ray shootRay;                                   
    RaycastHit shootHit;                            
    int shootableMask;  

    public GameObject rightHand;

    void Start()
    {
        transform.parent = rightHand.transform;
    }

   void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = gunBarrelEnd.GetComponent<ParticleSystem>();
        gunLine = gunBarrelEnd.GetComponent<LineRenderer>();
        gunAudio = gunBarrelEnd.GetComponent<AudioSource>();
        gunLight = gunBarrelEnd.GetComponent<Light>();
        gunAudio.mute = !AudioSettings.getIsOnSound();
        gunAudio.volume = AudioSettings.getVolumeSound();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    public void Shoot()
    {
        player.GetComponent<Animator>().SetTrigger("ShootingDefault");
        Invoke("ApplyShoot", 0.3f);
    }
    public void ApplyShoot()
    {
        
        timer = 0f;
        gunAudio.mute = !AudioSettings.getIsOnSound();
        gunAudio.volume = AudioSettings.getVolumeSound();
        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;

        Vector3 position = player.transform.position + Vector3.up * 1f;

        gunLine.SetPosition(0, position);

        shootRay.origin = position;
        shootRay.direction = player.transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot + GameStates.getDamage(), shootHit.point);
            }

            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
 
}