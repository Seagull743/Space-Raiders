using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public float freezespeed = 2;
    public static float Slow = 1;
    public static float freezeduration = 5;
    private float unfreezetime;
    public bool freezing = false;
    public float freezecooldown = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (freezing)
        {
            if (unfreezetime > 0)
            {
                StartFreezing();           
            }
            else if (unfreezetime <= 0)
            {
                UnFreezing();        
            }
        }
    }
    private void StartFreezing()
    {
        freezing = true;
        unfreezetime = freezeduration;
        unfreezetime--;
    }
    private void UnFreezing()
    {
        freezing = false;
        unfreezetime = 0;
    }
   
   
}



        
        
    


