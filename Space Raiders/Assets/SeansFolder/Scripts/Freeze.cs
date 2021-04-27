using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{

    public int freezespeed = 2;
    public int Slow = 1;
    public static int freezeduration = 5;
    private int unfreezetime;

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
                //Put Enemy FUnction Here
            }
            else if (unfreezetime <= 0)
            {
                UnFreezing();
                //Enemy Normal
            }
        }

    }
    private void StartFreezing()
    {
        freezing = true;
        unfreezetime = freezeduration;

    }
    private void UnFreezing()
    {
        freezing = false;
        Slow = 1;
        unfreezetime = 0;

    }

}

        
        
    


