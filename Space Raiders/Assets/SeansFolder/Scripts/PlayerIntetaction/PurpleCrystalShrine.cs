using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCrystalShrine : InteractiveObject
{
    public PurpleCrystal Crystal;
    public bool PurplePlaced = false;
    public GameObject CrystalIn;

    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if (Crystal.PurpleCrystalCollected == true)
        {
            CrystalIn.SetActive(true);
            Crystal.gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GameManager.PlacePurpleCrystal();
            //PurplePlaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }
}
