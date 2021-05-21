using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkCrystalShrine : InteractiveObject
{
    public GameObject Crystal;
    public static bool PinkCrystalplaced = false;

    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if (PinkCrystal.PinkCrystalCollected == true)
        {
            Crystal.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            PinkCrystalplaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }
}
