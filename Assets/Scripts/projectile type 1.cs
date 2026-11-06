using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using Unity.Mathematics;
public class projectiletype1 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    [SerializeField]private float Destorytime = 5f;
     public bool canAttack; // Allows player to attack nearby enemies
    public GameObject nearbyPlayer; // Empty gameobject that will store nearby enemy upon collision (with trigger collider)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = PlayerScript.Player.transform.gameObject; //GameObject.FindGameObjectWithTag("player");


        Vector3 direction = player.transform.position -transform.position;
        rb.linearVelocity = new Vector2 ( direction.x , direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);
 SetDestoryTime();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //  void OnTriggerExit2D(Collider2D collider)
    // {
    //     if (collider.CompareTag("Player"))
    //     {
    //         canAttack = false; // Prevent attack
    //         nearbyPlayer = null; // Removes enemy from nearbyEnemy reference when enemy exits collider
    //     }
    // }
    void SetDestoryTime()
    {
         Destroy(gameObject,Destorytime);
    }
}
