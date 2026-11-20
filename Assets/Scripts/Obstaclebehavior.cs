using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Obstaclebehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float minSpeed = 2.0f;
    public float maxSpeed = 50f;
    Rigidbody2D rb;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //(randomDirection *  randomSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //float randomSpeed = Random.Range(minSpeed, maxSpeed);
        // Vector2 randomDirection = Random.insideUnitCircle;
        // rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = -1;

        //PlayerMovement.Player.transform.position;

        if (PlayerScript.Player == null) return;
        //Debug.Log(PlayerMovement.Player.transform.position);
        if (transform.position.x < PlayerScript.Player.transform.position.x - 4)
        {
            transform.position = new Vector3(PlayerScript.Player.transform.position.x + 12, transform.position.y, transform.position.z);
            Debug.Log("here");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    // why no work what
}
