using System.Collections;
using System.Collections.Generic;
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
    // Start is called once before the first execution of Update
    void Start()
    {
        theWeapon = BossMelee.theWeapon.transform.gameObject;
        evilGuy = Boss.Enemy.transform.gameObject;

         StartCoroutine(SomeCoroutine());
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        yield return new WaitForSecondsRealtime(1f);
        yield return gameObject.GetComponent<Renderer>().enabled = true;
        //  StartCoroutine(StartingCororutine());

       // gameObject DangerZone;
        // Swinged = true;

        Debug.Log ("working");
        //Sthm sthm new Stuff
       
}
    }
}
