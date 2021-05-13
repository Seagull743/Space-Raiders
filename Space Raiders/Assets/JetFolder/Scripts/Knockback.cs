using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "dmgBox")
        {
            Vector3 knockbackDir = other.transform.position - transform.position;

            knockbackDir = -knockbackDir.normalized;

            GetComponent<Rigidbody>().AddForce(knockbackDir * force * 100);
        }
    }
}
