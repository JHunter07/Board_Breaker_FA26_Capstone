using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
//again
    public float Speed = 3f;
    private float playerClock;
     private Rigidbody2D rb;
     private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {
       
        rb.linearVelocity = moveInput * Speed;
      if (Time.deltaTime > 0)
        {
            playerClock+= 1;
        }
      
         if (playerClock > 30f)
        {
            playerClock = 0;
            Speed += 1;
         }else if (Speed >= 30)
        {
            Speed = 30f;
        }
         
    }
 void fixUpdate()
    {
       
        rb.linearVelocity = moveInput * Speed;
      if (Time.deltaTime > 0)
        {
            playerClock+= 1;
        }
      
         if (playerClock > 30f)
        {
            playerClock = 0;
            Speed += 1;
         }else if (Speed >= 30)
        {
            Speed = 30f;
        }
         
    }

    public void Move(InputAction.CallbackContext context)

    {
        moveInput = context.ReadValue<Vector2>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
//collision.gameObject.GetComponent<Rigidbody2D>().simulated=false;
        Destroy(gameObject);
    }
}