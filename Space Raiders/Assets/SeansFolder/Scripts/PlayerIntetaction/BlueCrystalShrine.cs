using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCrystalShrine : InteractiveObject
{
    public GameObject Crystal;
    public static bool BlueCrystalplaced = false;

    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if (BlueCrystal.BlueCrystalCollected == true)
        {
            Crystal.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            BlueCrystalplaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }
}
