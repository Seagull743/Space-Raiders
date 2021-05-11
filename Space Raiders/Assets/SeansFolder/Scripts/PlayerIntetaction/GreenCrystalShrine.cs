using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCrystalShrine : InteractiveObject
{
    public GameObject Crystal;
    public GameManager GM;
    public static bool GreenPlaced = false;

    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if(GreenCrystal.GreenCrystalCollected == true)
        {
            Crystal.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GreenPlaced = true;
        }
        else
        {
            GM.GetComponent<GameManager>().CrystalText();

        }
    }


}