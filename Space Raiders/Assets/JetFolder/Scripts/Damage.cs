using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool done;

    public int damage;

    [SerializeField]
    private bool boss = false;

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
                if (!boss)
                {
                    other.GetComponent<PlayerHealth>().TakeDamage();
                }
                else if (boss)
                {
                    other.GetComponent<PlayerHealth>().TakeDamageBoss();
                }
                
                done = true;
            }            
        }
    }
}
