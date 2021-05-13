using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCrystal : InteractiveObject
{
   
    public static bool GreenCrystalCollected = false;
    [SerializeField]
    private bool pickedup = false;

    void Start()
    {
        if (!pickedup)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public override void PlayerInteraction()
    {
        PickedupCrystal();
    }
    
    public void PickedupCrystal()
    {
        GameManager.TheScoreAdd();
        GreenCrystalCollected = true;
        pickedup = true;
        Destroy(gameObject);
    }

}
