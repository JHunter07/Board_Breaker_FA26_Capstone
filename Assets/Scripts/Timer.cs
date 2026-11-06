using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Timer : MonoBehaviour
{  
    //again
    public float GameTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if (GameTimer >= 0)
        {
            GameTimer += Time.deltaTime;

        
        }
        else if (GameTimer < 0)
        {
            GameTimer = 0;
        }
    }
}
