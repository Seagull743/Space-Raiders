using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    
    [SerializeField]
    private float timertoFreeze = 0;
    [SerializeField]
    private float timerunFreeze = 5;

    public  bool freezing = false;  
    public  bool freezingComplete = false;

    private bool CanFreeze = true;

    //Creating the FreezeHighlight
    [SerializeField]
    private Material normal;
    [SerializeField]
    private Material Frozen;

    [SerializeField]
    private int damageAmount;

    [SerializeField]
    private GameObject[] CharacterMesh;

    void Start()
    {
        foreach (GameObject CM in CharacterMesh)
        {
            CM.GetComponent<Renderer>().material = normal;
        }
        //gameObject.GetComponent<Renderer>().material = normal;    
    }

    void Update()
    {   
         if (freezing && CanFreeze == true)
         {
             timertoFreeze += Time.deltaTime;

             if (timertoFreeze >= 1)
                 {
                    Debug.Log("Frozen complete");
                foreach (GameObject CM in CharacterMesh)
                {
                    CM.GetComponent<Renderer>().material = Frozen;
                }
                //gameObject.GetComponent<Renderer>().material = Frozen;
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
                        }
       }
     
       if (!freezing)
       {
        timertoFreeze = 0;
     
        timerunFreeze = 5;
        }
    
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
        foreach (GameObject CM in CharacterMesh)
        {
            CM.GetComponent<Renderer>().material = normal;
        }
        //gameObject.GetComponent<Renderer>().material = normal;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shard")
        {
            if (freezingComplete == true)
            {
                if(this.gameObject.TryGetComponent<Health>(out var health))
                {
                    health.ShardDamage(damageAmount);
                }
                
            }
        }
    }

}




        
        
    


