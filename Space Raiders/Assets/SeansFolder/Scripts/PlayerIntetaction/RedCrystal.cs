using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCrystal : InteractiveObject
{
    public static bool RedCrystalCollected = false;
    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }

    public void PickedupCrystal()
    {
        GameManager.TheScoreAdd();
        RedCrystalCollected = true;
        Destroy(gameObject);
    }
}
