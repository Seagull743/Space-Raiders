using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBeam : MonoBehaviour
{
   
   
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            other.GetComponent<Freeze>().StartFreezing();
        }       
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            other.GetComponent<Freeze>().UnFreezing();
        }
    }


    

}
   

