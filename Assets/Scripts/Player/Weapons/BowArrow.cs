
using UnityEngine;

public class BowArrow : MonoBehaviour
{

    public float currentBowForce = 0f;
    public float maxBowForce;
    public GameObject player;

    private float theta = 0.75f;     // angle arrow is shot at
    private float originZ;
    private float originY;
    private Vector3 origin;
    private Vector3 directionZ;
    private float startTime;

    private int damagePerShot =  GameStates.getDamageWeapon(3);

    void Start()
    {
        startTime = Time.time;
        origin = transform.position;
        directionZ = player.transform.forward;
    }

    void Update()
    {   
            float deltaTime = Time.time - startTime;
            float translationZ = currentBowForce * Mathf.Cos(theta) * deltaTime;
            float translationY = currentBowForce * Mathf.Sin(theta) * deltaTime - (9.8f * deltaTime * deltaTime / 2);
            transform.position = origin + translationZ * directionZ + translationY * Vector3.up;

    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Arrow hit");
        if (collider.CompareTag("Enemy"))
        {
            Vector3 hitPoint = collider.ClosestPoint(transform.position);

            collider.GetComponent<EnemyHealth>().TakeDamage(damagePerShot + GameStates.getDamage(), hitPoint);
            Destroy(gameObject);
        }
    }
}

