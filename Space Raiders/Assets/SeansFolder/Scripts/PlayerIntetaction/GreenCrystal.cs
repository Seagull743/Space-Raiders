using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GreenCrystal : InteractiveObject
{
    public static bool GreenCrystalCollected = false;
    [SerializeField]
    private bool pickedup = false;

    void Start()
    {
        if (!pickedup)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }
    
    public void PickedupCrystal()
    {
        //GM.GetComponent<GameManager>().TheScoreInternal();
        GameManager.TheScoreAdd();
        GreenCrystalCollected = true;
        pickedup = true;
        FindObjectOfType<AudioManager>().Play("crystalCollect");
        GameAnalytics.NewDesignEvent("Crystal-green");
        Destroy(gameObject);
    }
}
