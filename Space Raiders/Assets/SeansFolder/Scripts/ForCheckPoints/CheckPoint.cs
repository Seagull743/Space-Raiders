using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public PlayerPos PP;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //GameManager.SetLastCheckpoint(transform.position); 
        }
    }
}
