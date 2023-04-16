using UnityEngine;
using System;
using System.Collections.Generic;

public class ShotgunShoot : MonoBehaviour
{
    public int damagePerShot = GameStates.getDamageWeapon(1);                  
    public float timeBetweenBullets = 0.15f;        
    public float range = 100f;   
    
    public GameObject[] gunBarrelEnds;
    public GameObject player;
    List<ParticleSystem> gunParticles = new List<ParticleSystem>();
    List<LineRenderer> gunLines = new List<LineRenderer>();                           
    AudioSource gunAudio;                           
    List<Light> gunLights = new List<Light>();                                
    float effectsDisplayTime = 0.2f; 

    float timer;                                    
    Ray[] shootRays = new Ray[5];                                   
    RaycastHit shootHit;                            
    int shootableMask;  

    public GameObject rightHand;

    void Start()
    {
        transform.parent = rightHand.transform;
    }
   void Awake()
    {
        gunAudio = gunBarrelEnds[0].GetComponent<AudioSource>();
        shootableMask = LayerMask.GetMask("Shootable");

        Array.ForEach(gunBarrelEnds, gunBarrelEnd =>
        {
            gunParticles.Add(gunBarrelEnd.GetComponent<ParticleSystem>());
            gunLines.Add(gunBarrelEnd.GetComponent<LineRenderer>());
            gunLights.Add(gunBarrelEnd.GetComponent<Light>());
        });
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
        gunLines.ForEach(gunLine => gunLine.enabled = false);
        gunLights.ForEach(gunLight => gunLight.enabled = false);
    }

    public void Shoot()
    {
        player.GetComponent<Animator>().SetTrigger("ShootingShotgun");
        Invoke("ApplyShoot", 0.3f);
    }

    public void ApplyShoot()
    {        
        timer = 0f;
        gunAudio.mute = !AudioSettings.getIsOnSound();
        gunAudio.volume = AudioSettings.getVolumeSound();
        gunAudio.Play();

        gunLights.ForEach(gunLight => gunLight.enabled = true);

        gunParticles.ForEach(gunParticle => gunParticle.Stop());
        gunParticles.ForEach(gunParticle => gunParticle.Play());

        gunLines.ForEach(gunLine => gunLine.enabled = true);

        Vector3 position = player.transform.position + Vector3.up * 1f;
        gunLines.ForEach(gunLine => gunLine.SetPosition(0, position));

        
        Array.ForEach(shootRays, shootRay => shootRay.origin = position);

        float transformAngle = -0.6f;
        for (int i = 0; i < 5; i++)
        {
            Vector3 direction = player.transform.forward;
            direction.x += transformAngle;
            shootRays[i].direction = direction;
            transformAngle += 0.3f;
        }

        for (int i = 0; i < 5; i++)
        {
            if (Physics.Raycast(shootRays[i], out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                // Debug.Log(enemyHealth);
                if (enemyHealth != null)
                {
                    float distance = Vector3.Distance(player.transform.position, shootHit.collider.transform.position);
                    int damage = (int)(damagePerShot * (1 - (distance / range)));
                    // Debug.Log("Damage: " + damage);
                    enemyHealth.TakeDamage(damage + GameStates.getDamage(), shootHit.point);
                    Debug.Log(shootHit.collider.gameObject.name + " got hit : " + damage + " damage");
                }

                gunLines[i].SetPosition(1, shootHit.point);
            }
            else
            {
                gunLines[i].SetPosition(1, shootRays[i].origin + shootRays[i].direction * range);
            }
        };

    }

}