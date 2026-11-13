using UnityEngine;

public class BossMelee : MonoBehaviour
{
    public static BossMelee theWeapon;

    public GameObject nearbyPlayer;
    public bool canAttack;
    public float attackCooldown = 5;//this
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Awake()
    {
        theWeapon = this;

    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger)
        {
            PlayerScript.Player.TakeDamage();
            gameObject.SetActive(false);
            //canAttack = true;
            //nearbyPlayer = collider.gameObject;
        }
    }
}
