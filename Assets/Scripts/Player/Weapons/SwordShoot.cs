using UnityEngine;

public class SwordShoot : MonoBehaviour
{
    public Animator anim;
    public int damage = 100;
    public GameObject RightHand;
    private  bool applyDamage = true;
    private float lastDamageTime = 0f;

    private int damagePerShot =  GameStates.getDamageWeapon(2);

    public void Start()
    {
        transform.parent = RightHand.transform;
    }

    public void Shoot()
    {
        anim.SetTrigger("SwingingSword");

    }

    void FixedUpdate()
    {
        float timer = Time.time - lastDamageTime;
        if (timer >= 0.5f)
        {
            applyDamage = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy") && applyDamage)
        {
            lastDamageTime = Time.time;
            applyDamage = false;
            Vector3 hitPoint = collider.ClosestPoint(transform.position);

            collider.GetComponent<EnemyHealth>().TakeDamage(damagePerShot + GameStates.getDamage(), hitPoint);
        }
    }


}