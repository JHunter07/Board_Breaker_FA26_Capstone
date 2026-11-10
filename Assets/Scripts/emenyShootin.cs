using System.Threading;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
      

        if(((distance > 5) && (patternActiveShot == false)) || (patternActiveArc == true) )// > far away from boss < Close to boss
        {
             

            if(timer > 2)
        {  
            shootLock();  
             timer = 0;    
            resetPattern += 1;

            
        }   if (distance <= 9)
            {
                resetPattern = 2;
            } 
         if (resetPattern >= 3)
            {
                patternActiveShot = true;
                patternActiveArc = false;
                resetPattern = 0;


            }

        }else if (((distance> 9) && (patternActiveArc == false)) || (patternActiveShot == true))
        {
            
            if(timer > 2)
        {
            timer = 0;
           shootArc(); 
           resetPattern += 1;

 
        }  if (distance > 11)
            {
                resetPattern = 1;
            }
        if (resetPattern >= 2)
            {
                patternActiveArc = true;
                 patternActiveShot = false;
                resetPattern = 0;
               
            }

        }

        
    }
    void shootLock()
    {
        //cloneing objects
        Instantiate(junk ,junkPos.position, Quaternion.identity);
           
           
       
        }
         
    void shootArc()
    {
       
         Instantiate(trash,trashPos.position, Quaternion.identity);
    }
    
}
