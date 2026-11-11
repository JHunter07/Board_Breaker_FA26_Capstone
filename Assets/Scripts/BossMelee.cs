using UnityEngine;

public class BossMelee : MonoBehaviour
{
    public static Boss Enemy; // 
    private Rigidbody2D rb; //
    public GameObject nearbyPlayer;
    public bool canAttack;
    bool hasAttacked;
    public float attackCooldown = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (nearbyPlayer != null)
            if (canAttack == true)
            {

                if (nearbyPlayer.GetComponent<PlayerScript>().health > 0)

                {

                    if (attackCooldown <= 0)
                    {

                        nearbyPlayer.GetComponent<PlayerScript>().TakeDamage(10);
                        attackCooldown = 5;
                    }
                }

                else
                {
                    //   Destroy(nearbyPlayer);
                }
            }
    
            }
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player") && !collider.isTrigger)
            {
                canAttack = true;
                nearbyPlayer = collider.gameObject;
            }
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.CompareTag("Player") && !collider.isTrigger)
            {
                canAttack = false;
                nearbyPlayer = null;
            }
        }

        // void OnCollisionEnter(Collision2D coll)
        //  {
        //  coll.gameObject.GetComponent<PlayerScript>().TakeDamage(10);

        //   Debug.Log("-10");
        //}

    

}
