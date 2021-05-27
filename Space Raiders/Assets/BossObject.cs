using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObject : InteractiveObject
{

    public override void PlayerInteraction()
    {
       SpawnBoss();
    }

    private void SpawnBoss()
    {
        if(GameManager.AllCrystalsPlaced())
        {
            GameManager.SetBossSpawned();  
        }
        else
        {
            GameManager.BossTextStart();
        }
    }
}
