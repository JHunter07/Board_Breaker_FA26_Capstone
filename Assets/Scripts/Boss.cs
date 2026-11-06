
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

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
    [SerializeField] GameObject hitBox; // Private but available in the inspector
    public int health = 100;


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
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = Mathf.Sin(Time.time * floating) * strength;
        Vector3 position = new Vector2(0, newY) + initialPosition;
        theRB.MovePosition(position);
        // Vector2 rawMove = moveInput.ReadValue<Vector2>();
        //  move = rawMove;
        // rb.linearVelocity = new Vector2(rb.linearVelocity.x,10f);
        // Debug.Log(rb.linearVelocity.y);
        if (canAttack)
        {
            // canAttack = Time.time > 1;
            if (!hitBox.activeInHierarchy) hitBox.SetActive(true);


            // Upon attacking, destroy nearbyEnemy if there is currently a reference to it 
            if (nearbyPlayer != null)
            {
                // Create timer to wait for attack
                canAttack = Time.time > 1;
                if (nearbyPlayer.GetComponent<PlayerScript>().health > 0)
                {
                    nearbyPlayer.GetComponent<PlayerScript>().TakeDamage(10);
                }
                else
                {
                    //Destroy(nearbyPlayer);
                }
                /// WTFFFFFFF


                if (!hitBox.activeInHierarchy) hitBox.SetActive(false); // Set hitbox active after timer goes off

                //
                // Destroy(nearbyPlayer);
                // TakeDamage(-5); // start with 10 health 

            }
            else
            {
                //Destroy (nearbyPlayer);
                Debug.Log("I will destroy you!!!");
            }
        }
        //}

    }
    //void Update()
    //{

    //    rb.linearVelocity = moveInput * Speed;
    //    if (Time.deltaTime > 0)
    //    {
    //        playerClock += 1;
    //    }

    //    if (playerClock > 30f)
    //    {
    //        playerClock = 0;
    //        Speed += 1;
    //    }
    //    else if (Speed >= 30)
    //    {
    //        Speed = 30f;
    //    }

    //}

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
        if (collider.CompareTag("Player"))
        {
            canAttack = false; // Prevent attack
            nearbyPlayer = null; // Removes enemy from nearbyEnemy reference when enemy exits collider
        }
    }

}
