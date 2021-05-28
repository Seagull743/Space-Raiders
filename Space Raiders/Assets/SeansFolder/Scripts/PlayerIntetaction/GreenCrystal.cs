using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GreenCrystal : InteractiveObject
{
   
    public bool GreenCrystalCollected = false;
    [SerializeField]
    
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }
    
    public void PickedupCrystal()
    {
        
        GameManager.TheScoreAdd();
        GameManager.CollectGreenCrystal();
        GreenCrystalCollected = true;
        FindObjectOfType<AudioManager>().Play("crystalCollect");
        GameAnalytics.NewDesignEvent("Crystal:green");
        this.gameObject.SetActive(false);
    }
}
