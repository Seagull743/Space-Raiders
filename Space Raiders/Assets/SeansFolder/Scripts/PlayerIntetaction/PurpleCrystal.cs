using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCrystal : InteractiveObject
{
    public static bool PurpleCrystalCollected = false;
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        GameManager.theScore += 1;
        PurpleCrystalCollected = true;
        Destroy(gameObject);
    }
}
