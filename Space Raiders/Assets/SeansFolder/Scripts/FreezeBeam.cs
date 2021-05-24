using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBeam : MonoBehaviour
{
   
   
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Melee") || other.gameObject.tag == ("Range") || other.gameObject.tag == ("Boss") || other.gameObject.tag == ("Platform"))
        {
            other.GetComponent<Freeze>().StartFreezing();
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Melee") || other.gameObject.tag == ("Range") || other.gameObject.tag == ("Boss") || other.gameObject.tag == ("Platform"))
        {
            other.GetComponent<Freeze>().UnFreezing();
        }
    }


    

}
   

