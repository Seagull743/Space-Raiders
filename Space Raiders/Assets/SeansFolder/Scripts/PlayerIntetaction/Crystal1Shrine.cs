using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal1Shrine : InteractiveObject
{
    public GameObject Crystal;
    public GameManager GM;
    
    public override void PlayerInteraction()
    {
        PlaceCrystal();
    }

    public void PlaceCrystal()
    {
        if(Crystal1.GreenCrystalCollected == true)
        {
            Crystal.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GM.GetComponent<GameManager>().CrystalText();

        }
    }


}