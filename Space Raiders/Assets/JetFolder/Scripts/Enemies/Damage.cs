using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject player;

    public float damage;

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Player")
        {
            //player.health -= damage;
        }
    }
}
