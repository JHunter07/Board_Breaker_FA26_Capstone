using System;
using UnityEngine;

public class projectiletype2 : MonoBehaviour
{
[Header("General Stats")]
    [SerializeField]private LayerMask whatDestoryBullet;
    [SerializeField]private float Destorytime = 3f;
     
[Header("Normal Stats")]
   [SerializeField]private float normalBulletSpeed = 15f;
[Header("Physics Stats")]
    [SerializeField] private float pyhsicsBulletSpeed = 17.5f;
    [SerializeField] private float pyhsicsBulletGravity = 3f;
    private Rigidbody2D rb;
   
    public enum BulletType
    {
        Normal,
        Physics
    }
    public BulletType bulletType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Start()
    {
        rb = GetComponent <Rigidbody2D> ();

        SetDestoryTime();

        SetRBStats();

        InitializeBulletStats();

    }
private void InitializeBulletStats()
    {
        if (bulletType == BulletType.Normal)
        {
            SetStraightVelocity();
        }
        else if (bulletType == BulletType.Physics)
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatDestoryBullet.value & (1 << collision.gameObject.layer))> 0)
        {
            Destroy(gameObject);
        }
    }
    private void SetStraightVelocity()
    {
        rb.linearVelocity = transform.right * normalBulletSpeed;
    }
    private void SetPhysicsVelocity()
    {
        rb.linearVelocity = transform.right * pyhsicsBulletSpeed;
    }
    private void SetDestoryTime()
    {
        Destroy(gameObject,Destorytime);
    }
    private void SetRBStats()
    {
        if(bulletType == BulletType.Normal)
        {
            rb.gravityScale = 0f;
        }
        else if (bulletType == BulletType.Physics)
        {
            rb.gravityScale = pyhsicsBulletGravity;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
