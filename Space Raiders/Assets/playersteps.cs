using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersteps : MonoBehaviour
{
    //[SerializeField]
   // private AudioSource step;


    private void footstepPlay()
    {
        //step.Play();
        FindObjectOfType<AudioManager>().Play("PlayerFootStep");
    }

}
