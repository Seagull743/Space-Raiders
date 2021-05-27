using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Crystal.gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GameManager.PlaceGreenCrystal();
            //GreenPlaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }


}