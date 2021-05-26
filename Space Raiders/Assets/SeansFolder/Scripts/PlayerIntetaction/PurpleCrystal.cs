using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class PurpleCrystal : InteractiveObject
{
    public static bool PurpleCrystalCollected = false;

   
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        GameManager.TheScoreAdd();
        PurpleCrystalCollected = true;
        FindObjectOfType<AudioManager>().Play("crystalCollect");
        GameAnalytics.NewDesignEvent("Crystal-purple");
        Destroy(gameObject);     
    }
}
