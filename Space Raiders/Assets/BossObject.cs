﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObject : InteractiveObject
{
    public static bool boss = false;
    public GameManager gameManager;
    public override void PlayerInteraction()
    {
       SpawnBoss();
    }

    private void SpawnBoss()
    {
        if(BlueCrystalShrine.BlueCrystalplaced == true && GreenCrystalShrine.GreenPlaced == true && PurpleCrystalShrine.PurplePlaced == true && PinkCrystalShrine.PinkCrystalplaced == true)
        {
            boss = true;
        }
        else
        {
            gameManager.GetComponent<GameManager>().BossTextStart();
        }
    }
}