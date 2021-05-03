using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public float timertoFreeze = 0;

    public float timerunFreeze = 5;
        

    public  bool freezing = false;
    public  bool freezingComplete = false;
    public  float freezeslow = -3f;
    public bool canFreeze = true;

    //Creating the FreezeHighlight
    public Material normal;
    public Material Frozen;


     void Start()
    {
        gameObject.GetComponent<Renderer>().material = normal;    
    }


    void Update()
    {
       
        
         if (freezing)
         {
             timertoFreeze += Time.deltaTime;

             if (timertoFreeze >= 2)
                 {
                    Debug.Log("Frozen complete");
                    gameObject.GetComponent<Renderer>().material = Frozen;
                    freezingComplete = true;

                        if (freezingComplete == true)
                        {
                                
                             if (timerunFreeze >= 0)
                                {
                                    timerunFreeze -= Time.deltaTime;
                                }
                             else
                                {
                                    Invoke("TheTimer", 1.5f);
                                }
                            }
                        }
       }
       else if (!freezing)
       {
           timertoFreeze = 0;
           freezingComplete = false;
            timerunFreeze = 5;
        }
    
        
        if(freezingComplete && freezing)
        {
            timerunFreeze -= Time.deltaTime;
        }     

    }

    public void StartFreezing()
    {
        freezing = true;
        
    }

    public void UnFreezing()
    {
        freezing = false;
        timertoFreeze = 0;
    }

    public void TheTimer()
    {
        freezing = false;
        freezingComplete = false;
        Debug.Log("I've been unfrozen");
        gameObject.GetComponent<Renderer>().material = normal;
    }
}



        
        
    


