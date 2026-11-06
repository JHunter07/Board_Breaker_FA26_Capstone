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
        Destroy(gameObject);
    }
}
