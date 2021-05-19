using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCrystalShrine : InteractiveObject
{
    public GameObject Crystal;
    public static bool YellowCrystalplaced = false;

    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if (YellowCrystal.YellowCrystalCollected == true)
        {
            Crystal.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            YellowCrystalplaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }
}
