using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCrystalShrine : InteractiveObject
{
    public GameObject Crystal;
    public GameManager GM;
    public static bool PurplePlaced = false;

    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if (PurpleCrystal.PurpleCrystalCollected == true)
        {
            Crystal.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            PurplePlaced = true;
        }
        else
        {
            GM.GetComponent<GameManager>().CrystalText();
        }
    }
}
