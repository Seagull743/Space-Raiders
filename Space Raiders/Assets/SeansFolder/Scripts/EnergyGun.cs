using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGun : InteractiveObject
{
    public static bool EnergyPickedUp = false;
    public GameManager GM;
    
    public override void PlayerInteraction()
    {
        SerumPickedup();    
    }
   
    public void SerumPickedup()
    {
        EnergyPickedUp = true;
        GM.GetComponent<GameManager>().EnergyTextCoroutine();
        Destroy(gameObject);
    }
}
