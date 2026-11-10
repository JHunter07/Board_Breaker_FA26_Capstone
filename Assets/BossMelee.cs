using UnityEngine;

public class BossMelee : MonoBehaviour
{
    public GameObject nearbyPlayer;
    public bool canAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (nearbyPlayer.GetComponent<PlayerScript>().health > 0)
        {
            nearbyPlayer.GetComponent<PlayerScript>().TakeDamage(10);
        }
        else
        {
            Destroy(nearbyPlayer);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag("Player"))
        {
            canAttack = true; 
            nearbyPlayer = collider.gameObject; 
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
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
