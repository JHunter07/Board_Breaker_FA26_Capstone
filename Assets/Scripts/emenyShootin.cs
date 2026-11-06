using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class emenyShootin : MonoBehaviour
{
   public GameObject junk;
   public Transform junkPos;
    public GameObject trash;
   public Transform trashPos;
   
   private float timer;
   private GameObject player;
   public bool patternActiveShot;
   public bool patternActiveArc;  
   private float resetPattern = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerScript.Player.transform.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);   
       Debug.Log(distance);//check range & fire
       
        if((distance > 5) && (patternActiveArc = false))// > far away from boss < Close to boss
        {
            if(timer > 2)
        {
            timer = 0;
            shootLock();
            patternActiveShot= true;
            resetPattern = +1;
        } if (resetPattern > 3)
            {
                patternActiveShot=false;
                resetPattern= 0;
            }


        }else if ((distance> 8)&& (patternActiveShot = false))
        {
            if(timer > 4)
        {
            timer = 0;
           shootArc(); 
            patternActiveArc = true;
            resetPattern = +1;

        }  if (resetPattern > 4)
            {
                patternActiveArc=false;
                resetPattern= 0;
            }
        }

        
    }
    void shootLock()
    {
        Instantiate(junk,junkPos.position, Quaternion.identity);
        
        }
         
    void shootArc()
    {
       
         Instantiate(trash,trashPos.position, Quaternion.identity);
    }
    
}
