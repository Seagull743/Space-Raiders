using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public float timertoFreeze = 0;

    public float timerunFreeze = 5;
        

    public  bool freezing = false;
    public  bool freezingComplete = false;

    private bool CanFreeze = true;

    //Creating the FreezeHighlight
    public Material normal;
    public Material Frozen;


     void Start()
    {
        gameObject.GetComponent<Renderer>().material = normal;    
    }


    void Update()
    {
       
        
         if (freezing && CanFreeze == true)
         {
             timertoFreeze += Time.deltaTime;

             if (timertoFreeze >= 1.5)
                 {
                    Debug.Log("Frozen complete");
                    gameObject.GetComponent<Renderer>().material = Frozen;
                    freezingComplete = true;

                        if (freezingComplete == true)
                        {                           
                             CanFreeze = false;                           
                            if(TryGetComponent<MoveObject>(out var moveObject))
                            {
                                moveObject.Frozen();
                            } 

                            if(TryGetComponent<Platform>(out var platform))
                            {
                                platform.Frozen();
                            }
                                                 
                             Invoke("TheTimer", 5f);
                             
                             //if (timerunFreeze >= 0)
                               // {
                              //      timerunFreeze -= Time.deltaTime;
                              //  }
                             //else
                             //   {
                              //      Invoke("TheTimer", 1.5f);
                              //  }
                           // }
                        }
       }
       //else 
       if (!freezing)
       {
        timertoFreeze = 0;
           //freezingComplete = false;
        timerunFreeze = 5;
        }
    
        //if(freezingComplete == true)
       // {
        //    Invoke("TheTimer", 4f);
      //  }
        
        //if(freezingComplete && freezing)
       // {
       //     timerunFreeze -= Time.deltaTime;
       // }     

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
        CanFreeze = true;
        timertoFreeze = 0;
        if(TryGetComponent<MoveObject>(out var moveObject))
            {
                moveObject.UnFrozen();
            }

        if(TryGetComponent<Platform>(out var platform))
            {
                platform.UnFrozen();
            }
    }
}



        
        
    


