using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class BlueCrystalShrine : InteractiveObject
{
    public BlueCrystal Crystal;
    public bool BlueCrystalplaced = false;
    public GameObject CrystalIn;
    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if (Crystal.BlueCrystalCollected == true)
        {
            CrystalIn.SetActive(true);
            Crystal.gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GameManager.PlaceBlueCrystal();
            GameAnalytics.NewDesignEvent("CrystalPlaced:blueplaced");
            //BlueCrystalplaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }
}
