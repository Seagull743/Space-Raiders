﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    void Update()
    {
        if (GreenCrystalShrine.GreenPlaced == true && PinkCrystalShrine.PinkCrystalplaced == true && PurpleCrystalShrine.PurplePlaced == true)
        {
            SceneManager.LoadScene("randomscene");
        }
    }
}
