using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class BlueCrystal : InteractiveObject
{
    public static bool BlueCrystalCollected = false;
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        GameManager.TheScoreAdd();
        BlueCrystalCollected = true;
        FindObjectOfType<AudioManager>().Play("crystalCollect");
        GameAnalytics.NewDesignEvent("Crystal-blue");
        Destroy(gameObject);
    }
}
