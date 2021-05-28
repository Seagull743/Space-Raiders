using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBeam : MonoBehaviour
{
   
   
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Melee") || other.gameObject.tag == ("Range") || other.gameObject.tag == ("Boss") || other.gameObject.tag == ("Platform"))
        {
           if(other.TryGetComponent<Freeze>(out var AI))
            {
                AI.StartFreezing();
            }
            //other.GetComponent<Freeze>().StartFreezing();
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Melee") || other.gameObject.tag == ("Range") || other.gameObject.tag == ("Boss") || other.gameObject.tag == ("Platform"))
        {
           if(other.TryGetComponent<Freeze>(out var AI))
            {
                AI.UnFreezing();
            }
            //other.GetComponent<Freeze>().UnFreezing();
        }
    }


    

}
   

