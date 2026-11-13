using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

public class ArcShotV2 : MonoBehaviour
{
  
[Header("General Stats")]
    [SerializeField]private LayerMask whatDestoryBullet;
    [SerializeField]private float Destorytime = 5f;
     
[Header("Physics Stats")]
    [SerializeField] private float pyhsicsBulletSpeed = 17.5f;
    [SerializeField] private float pyhsicsBulletGravity = 3f;
    [SerializeField]public float force = 0f;
    [SerializeField] public float mass= 0f;
    [SerializeField] public float drag = 0f;
    private Rigidbody2D rb;
     private GameObject player;
    private GameObject boss;
  [SerializeField] private AnimationCurve trijectoryanimationCurve;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
SetDestoryTime();

        
       
        
        //lock on script
  rb = GetComponent<Rigidbody2D>();
        player = PlayerScript.Player.transform.gameObject; //GameObject.FindGameObjectWithTag("player");
        boss = Boss.Enemy.transform.gameObject;

    
 
        Vector3 direction = player.transform.position   -boss.transform.position;
        rb.linearVelocity = new Vector2 ( direction.x, direction.y).normalized  * force;

         rb.gravityScale = pyhsicsBulletGravity;
        //rotation of object
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot );
    }

   
  
    void SetDestoryTime()
    {
         Destroy(gameObject,Destorytime);
    }
   
    // Update is called once per frame
    void Update()
   {
    
        
    }
   public void IntainlizeAnimationCurve(AnimationCurve trijectoryAnimationCurve)
    {
        //this.trijectoryanimationCurve = trijectoryanimationCurve;
    }
}
