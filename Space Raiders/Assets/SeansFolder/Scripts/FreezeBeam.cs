using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBeam : MonoBehaviour
{
    public static float timertoFreeze = 0;
    public float timerunFreeze = 3;
    public static bool freezing = false;
    public static bool freezingComplete = false;
    public static float freezeslow = -3f;
    void Update()
    {
        if (freezing)
        {
            timertoFreeze += Time.deltaTime;

            if(timertoFreeze >= 2)
            {
                Debug.Log("Frozen complete");
                freezingComplete = true;

                if (freezingComplete == true)
                {
                                   
                    if (timerunFreeze > 0)
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
        else if(!freezing)
        {
            timertoFreeze = 0;
            freezingComplete = false;
            timerunFreeze = 5;
        }

    }
    public void TheTimer()
    {
        freezing = false;
        freezingComplete = false;
        Debug.Log("I've been unfrozen");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            freezing = true;
            Debug.Log("I'm freezing");      
        }
        else
        {
            timertoFreeze = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            freezing = false;
            timertoFreeze = 0;
        }
    }
}
