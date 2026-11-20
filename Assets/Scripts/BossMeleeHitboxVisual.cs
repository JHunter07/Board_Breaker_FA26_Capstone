using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
//using System.Drawing;
using System.Net.NetworkInformation;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class BossMeleeHitboxVisual : MonoBehaviour
{
    public bool Swinged = false;
    public GameObject theWeapon;
    public GameObject evilGuy;
    public GameObject DangerZone;
    public Renderer box;
    //  Color color = Color.Red;
     
    // float attackImageAlpha = 0f;
     
    // Start is called once before the first execution of Update
    void Start()
    {
       //  DangerZone.sprite = color.red;
        // color.A = attackImageAlpha;
        // attackImageAlpha  = 0;

        //theWeapon = BossMelee.theWeapon.transform.gameObject;
        evilGuy = Boss.Enemy.transform.gameObject;

         StartCoroutine(SomeCoroutine());
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // DangerZone.color = color;
       //StartCoroutine(SomeCoroutine());
    }
     private IEnumerator StartingCororutine()
    {
        
        
            
          
         yield return  StartCoroutine(SomeCoroutine());//waits for other to go before it go
        
         yield return new WaitForSecondsRealtime(4f);
         yield return gameObject.GetComponent<Renderer>().enabled = false;
       
        Debug.Log("looping");
         
    }
    private IEnumerator SomeCoroutine()
    {
     while (true){   
        
        //Do something
        // Swinged= false;
        
        // Debug.Log ("not working");
        // attackImageAlpha =+ 0.10;
        yield return new WaitForSecondsRealtime(0.5f);
        yield return gameObject.GetComponent<Renderer>().enabled = true;
         yield return new WaitForSecondsRealtime(0.5f);
         yield return gameObject.GetComponent<Renderer>().enabled = false;
        //   attackImageAlpha = 0;
        //  StartCoroutine(StartingCororutine());

            // gameObject DangerZone;
            // Swinged = true;

       // Debug.Log ("working");
        //Sthm sthm new Stuff
       
}
    }
}
