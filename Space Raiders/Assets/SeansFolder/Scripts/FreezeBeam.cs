using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBeam : MonoBehaviour
{
    public float timertoFreeze = 0;
    public float timerunFreeze = 5;
    public static bool freezing = false;
    public static float freezeslow = -3f;
    void Update()
    {
        if (freezing)
        {
            timertoFreeze += Time.deltaTime;

            if(timertoFreeze >= 2)
            {
                Debug.Log("Frozen complete");             
                
                if(timerunFreeze >= 0)
                {
                    timerunFreeze -= Time.deltaTime;
                    
                    if(timerunFreeze == 0)
                    {
                        Invoke("TheTimer", 3);
                    }         
                }
                //Get the enemys component speed etc
            }
        }
        else if(!freezing)
        {
            timertoFreeze = 0;
        }
    }

    public void TheTimer()
    {
        freezing = false;
        Debug.Log("I've been unfrozen");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            freezing = true;
            Debug.Log("I'm freezing");      
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            freezing = false;       
        }
    }
}
