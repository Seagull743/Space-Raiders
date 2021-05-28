using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GreenCrystalShrine : InteractiveObject
{
    public GreenCrystal Crystal;
    public bool GreenPlaced = false;
    public GameObject CrystalIn;

    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if(Crystal.GreenCrystalCollected == true)
        {
            CrystalIn.SetActive(true);
            Crystal.gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GameManager.PlaceGreenCrystal();
            GameAnalytics.NewDesignEvent("CrystalPlaced:greenplaced");
            //GreenPlaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }


}