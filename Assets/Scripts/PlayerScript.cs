using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEditor;

public class PlayerScript : MonoBehaviour
{
    //again
    public static PlayerScript Player;
    public float Speed = 3f;
    private float playerClock;
    private Rigidbody2D rb;
    private InputAction moveInput;

    Vector2 move;
    public bool canAttack; // Allows player to attack nearby enemies
    public GameObject nearbyEnemy; // Empty gameobject that will store nearby enemy upon collision (with trigger collider)

    public int health = 100;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Player = this;

    }
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rawMove = moveInput.ReadValue<Vector2>();
        move = rawMove;
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            // Upon attacking, destroy nearbyEnemy if there is currently a reference to it 
            if (nearbyEnemy != null)
            {
                if (nearbyEnemy.GetComponent<Boss>().health > 0)
                {
                    nearbyEnemy.GetComponent<Boss>().TakeDamage(10);
                }
                else
                {
                    Destroy(nearbyEnemy);
                }
            }
            else
            {
                Debug.Log("THERE IS NO ENEMY HERE");
            }

            if (Time.deltaTime > 0)
            {
                playerClock += 1;
            }

            if (playerClock > 300f)
            {
                playerClock = 0;
                Speed += 1;
            }
            else if (Speed >= 30)
            {
                Speed = 30f;
            }

        }
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
        //Destroy(gameObject);
       // Speed = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if an enemy enters collider
        if (collider.CompareTag("Boss"))
        {
            canAttack = true; // Allow attack
            nearbyEnemy = collider.gameObject; // Sets collision object to the nearbyEnemy object reference
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Boss"))
        {
            canAttack = false; // Prevent attack
            nearbyEnemy = null; // Removes enemy from nearbyEnemy reference when enemy exits collider
        }
    }

    public void TakeDamage(int amt)
    {
        health -= amt;
    }



    void OnCollisionEnter(Collision col)
    {
        col.gameObject.GetComponent<PlayerScript>().TakeDamage(5);

        Debug.Log("-5");
    }






}
