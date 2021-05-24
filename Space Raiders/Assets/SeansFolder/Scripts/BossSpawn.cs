using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject bossSpawn;

    
    void Update()
    {
        if (GreenCrystalShrine.GreenPlaced == true && PurpleCrystalShrine.PurplePlaced == true && RedCrystalShrine.redCrystalplaced == true)
        {
            GameManager.BossSpawn(bossSpawn);            
        }
    }
}
