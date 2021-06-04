using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCrystal : InteractiveObject
{
    public static bool YellowCrystalCollected = false;
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        GameManager.TheScoreAdd();
        YellowCrystalCollected = true;
        Destroy(gameObject);
    }
}
