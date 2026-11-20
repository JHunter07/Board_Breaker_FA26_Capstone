using UnityEngine;
//again
public class Obstaclebehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void onCollisionEnter2d(Collision2D collision)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log("IS THIS WORKING");
            col.gameObject.GetComponent<PlayerScript>().TakeDamage();

          //  Destroy(gameObject);
          transform.position = new Vector3(PlayerScript.Player.transform.position.x + 12, transform.position.y, transform.position.z);
        }
        
        
        
    }
}
