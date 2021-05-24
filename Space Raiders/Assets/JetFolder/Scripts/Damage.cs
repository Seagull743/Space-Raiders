using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool done;

    public int damage;

    private void OnEnable()
    {
        done = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!done)
            {
                other.GetComponent<PlayerHealth>().TakeDamage();
                done = true;
            }            
        }
    }
}
