using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class PinkCrystalShrine : InteractiveObject
{
    public PinkCrystal Crystal;
    public bool PinkCrystalplaced = false;
    public GameObject CrystalIn;
    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if (Crystal.PinkCrystalCollected == true)
        {
            CrystalIn.SetActive(true);
            Crystal.gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GameAnalytics.NewDesignEvent("CrystalPlaced:pinkplaced");
            GameManager.PlacePinkCrystal();
            //PinkCrystalplaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }
}
