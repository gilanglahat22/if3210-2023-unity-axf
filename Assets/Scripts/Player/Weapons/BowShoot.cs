using UnityEngine;

public class BowShoot : MonoBehaviour
{
    // public GameObject arrowPrefab;
    // public GameObject player;
    // public float pullDistance = 2f;
    // public float maxBowForce = 1f;
    // GameObject newArrow;


    // private void Update()
    // {
    //     if (newArrow!= null)
    //     {
    //         Rigidbody arrowRigidbody = GetComponent<Rigidbody>();
    //         arrowRigidbody.transform.Translate(Vector3.up * 1f * Time.deltaTime);
    //     }
    // }

    // public void Shoot()
    // {
    //     newArrow = Instantiate(arrowPrefab, player.transform.position, player.transform.rotation);
    //     Rigidbody arrowRigidbody = newArrow.GetComponent<Rigidbody>();
        
    //     Vector3 arrowDirection = player.transform.forward;
    //     arrowDirection = Quaternion.Euler(-90f, 0f, 0f) * arrowDirection;
        
    //     float pullStrength = 1f;


    //     float arrowSpeed = 1f;
    
    //     Vector3 arrowVelocity = arrowDirection * arrowSpeed * pullStrength;
    //     arrowRigidbody.velocity = arrowVelocity;

    // }

    public GameObject arrowPrefab;
    public GameObject player;
    public Animator anim;
    public GameObject leftHand;

    private  bool applyDamage = true;
    private float lastDamageTime = 0f;
    public BowForce bowForce;

    public void Start()
    {
        transform.parent = leftHand.transform;
    }

    void FixedUpdate()
    {
        float timer = Time.time - lastDamageTime;
        if (timer >= 0.5f)
        {
            applyDamage = true;
        }
    }

    public void Shoot()
    {
        bowForce.UpdateBowForceBar(0f);
        if (applyDamage)
        {
            lastDamageTime = Time.time;
            applyDamage = false;

            anim.SetTrigger("PullingBow");
            Invoke("ReleaseBow", 0.3f);
        }

    }

    void ReleaseBow()
    {
        GameObject newArrow = (GameObject) Instantiate(arrowPrefab, arrowPrefab.transform.position, arrowPrefab.transform.rotation);
        newArrow.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);

    }

}