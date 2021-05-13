using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCrystalShrine : InteractiveObject
{
    public GameObject Crystal;
    public static bool redCrystalplaced = false;

    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if (RedCrystal.RedCrystalCollected == true)
        {
            Crystal.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            redCrystalplaced = true;
        }
        else
        {
            GameManager.CrystalText();
        }
    }
}
