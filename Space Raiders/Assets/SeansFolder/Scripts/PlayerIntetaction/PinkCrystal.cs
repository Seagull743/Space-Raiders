using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkCrystal : InteractiveObject
{
    public static bool PinkCrystalCollected = false;
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        GameManager.TheScoreAdd();
        PinkCrystalCollected = true;
        Destroy(gameObject);
    }
}
