using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

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
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Game", "ShootingCollected");
        GameAnalytics.NewDesignEvent("ShootingCollected");
        GameManager.EnergyTextCoroutine();
        Destroy(gameObject);
    }
}
