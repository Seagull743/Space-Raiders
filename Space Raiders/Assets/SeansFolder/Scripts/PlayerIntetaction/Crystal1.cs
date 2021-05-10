using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal1 : InteractiveObject
{
    public static bool GreenCrystalCollected = false;
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }
    
    public void PickedupCrystal()
    {
        GameManager.theScore += 1;
        GreenCrystalCollected = true;
        Destroy(gameObject);
    }

}
