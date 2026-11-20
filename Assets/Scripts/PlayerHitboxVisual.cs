using System.Collections;
using UnityEngine;


public class PlayerHitboxVisual : MonoBehaviour
{
    
    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      player = PlayerScript.Player.transform.gameObject;

        StartCoroutine(SomeCoroutine());
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private IEnumerator SomeCoroutine()
    {
     while (true){   
        
        //Do something
        // Swinged= false;
        
        // Debug.Log ("not working");
        // attackImageAlpha =+ 0.10;

       
       if (Input.GetKeyDown(KeyCode.E) && PlayerScript.Player.canAttack){
        
       
        yield return gameObject.GetComponent<Renderer>().enabled = true;
yield return new WaitForSecondsRealtime(0.2f);
       } else{
      //yield return new WaitForSecondsRealtime(0.5f);

         yield return gameObject.GetComponent<Renderer>().enabled = false;}
        //   attackImageAlpha = 0;
        //  StartCoroutine(StartingCororutine());

       // gameObject DangerZone;
        // Swinged = true;

       // Debug.Log ("working");
        //Sthm sthm new Stuff
       
}
    }
}
