
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //again
    public static Boss Enemy;
    public float Speed = 3f;
    //private float playerClock;
    private Rigidbody2D rb;
    private Rigidbody2D theRB;
    private Vector2 initialPosition;
    // private InputAction moveInput;
    Vector2 move;
    public bool canAttack; // Allows player to attack nearby enemies
    public GameObject nearbyPlayer; // Empty gameobject that will store nearby enemy upon collision (with trigger collider)
    public float floating = 10;
    public float strength = 1;
    [Space(15)]
    [Header("Hit Detection")]
    [Tooltip("Add Boss attack collider")]
    [SerializeField] GameObject bossMelee; // Private but available in the inspector
    public int health = 100;
    float time;

    public float attackCooldown = 10f;
    Color color = Color.red;
    public Image attackIcon;
    float attackImageAlpha = 0f;
    float counter = 0f;
    bool hasAttacked;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Enemy = this;

    }
    void Start()
    {
        // moveInput = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        theRB = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        attackIcon.color = color;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        attackIcon.color = color;
        color.a = attackImageAlpha;


        float newY = Mathf.Sin(Time.time * floating) * strength;
        Vector3 position = new Vector2(0, newY) + initialPosition;
        theRB.MovePosition(position);
        // Vector2 rawMove = moveInput.ReadValue<Vector2>();
        //  move = rawMove;
        // rb.linearVelocity = new Vector2(rb.linearVelocity.x,10f);
        // Debug.Log(rb.linearVelocity.y
        // 
        if (canAttack)
        {
            //Debug.Log("WHERE AM I");
            if(nearbyPlayer != null)
            {
                if(attackCooldown > 0f)
                {
                    attackCooldown -= Time.deltaTime;
                }
                else if (!hasAttacked)
                {
                    hasAttacked = true;
                    StartCoroutine(AttackPlayer());
                }
            }
        }
  

        if(hasAttacked)
        {
            counter++;
            attackImageAlpha = Mathf.Sin(counter * 0.03f);
        }


    }

    public void Move(InputAction.CallbackContext context)

    {
        //moveInput = context.ReadValue<Vector2>();
        // Debug.Log("YERR");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<Rigidbody2D>().simulated=false;
        Destroy(gameObject);
        Speed = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if an enemy enters collider
        if (collider.CompareTag("Player"))
        {
            canAttack = true; // Allow attack
            nearbyPlayer = collider.gameObject; // Sets collision object to the nearbyEnemy object reference
        }
    }
    public void TakeDamage(int amt)
    {
        health -= amt;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && collider.isTrigger)
        {
            canAttack = false; // Prevent attack
            nearbyPlayer = null; // Removes enemy from nearbyEnemy reference when enemy exits collider
        }
    }

    IEnumerator AttackPlayer()
    {
        Debug.Log("START THE ATTACK");
        yield return new WaitForSeconds(3);
        Debug.Log("THREE SECONDS HAVE PASSED");
        bossMelee.SetActive(true);
        hasAttacked = false;
        counter = 0f;
        attackImageAlpha = 0f;
        attackCooldown = 3f;
        Invoke(nameof(TurnOffHitbox), 0.5f);
    }

    void TurnOffHitbox()
    {
        if (bossMelee.activeInHierarchy) bossMelee.SetActive(false);
    }

    public void ResetAttack()
    {
        time = 10; //
    }

}
