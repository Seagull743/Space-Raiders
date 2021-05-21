using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCrystal : InteractiveObject
{
    public static bool BlueCrystalCollected = false;
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        GameManager.TheScoreAdd();
        BlueCrystalCollected = true;
        Destroy(gameObject);
    }
}
