using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class PinkCrystal : InteractiveObject
{
    public bool PinkCrystalCollected = false;
    
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        //GM.GetComponent<GameManager>().TheScoreInternal();
        GameManager.TheScoreAdd();
        GameManager.CollectPinkCrystal();
        PinkCrystalCollected = true;
        FindObjectOfType<AudioManager>().Play("crystalCollect");
        //GameAnalytics.NewDesignEvent("Crystal-pink");
        this.gameObject.SetActive(false);
    }
}
