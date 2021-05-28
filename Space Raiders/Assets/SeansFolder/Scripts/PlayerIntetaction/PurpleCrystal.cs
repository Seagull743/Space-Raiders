using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class PurpleCrystal : InteractiveObject
{
    public bool PurpleCrystalCollected = false;

    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        GameManager.TheScoreAdd();
        GameManager.CollectPurpleCrystal();
        PurpleCrystalCollected = true;
        FindObjectOfType<AudioManager>().Play("crystalCollect");
        GameAnalytics.NewDesignEvent("Crystal:purple");
        this.gameObject.SetActive(false); 
    }
}
