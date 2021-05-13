using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGun : InteractiveObject
{
    public static bool EnergyPickedUp = false;
    
    public override void PlayerInteraction()
    {
        SerumPickedup();    
    }
   
    public void SerumPickedup()
    {
        EnergyPickedUp = true;
        GameManager.EnergyTextCoroutine();
        Destroy(gameObject);
    }
}
