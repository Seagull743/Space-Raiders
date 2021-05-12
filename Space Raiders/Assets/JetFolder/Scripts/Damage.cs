using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Rigidbody playerRB;

    public Vector3 knockbackDir;

    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Health>().ShardDamage(damage);
        }
    }
}
