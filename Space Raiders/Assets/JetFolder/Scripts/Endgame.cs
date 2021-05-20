using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    public bool green;
    public bool red;
    public bool purple;

    // Start is called before the first frame update
    void Start()
    {
        green = GreenCrystalShrine.GreenPlaced;
        red = RedCrystalShrine.redCrystalplaced;
        purple = PurpleCrystalShrine.PurplePlaced;
    }

    // Update is called once per frame
    void Update()
    {
        if (green == true && red == true && purple == true)
        {
            
        }
    }
}
