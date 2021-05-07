using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 hitpoint;

    public int shardDmg = 20;

    public int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitpoint - this.transform.position).normalized * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().ShardDamage(shardDmg);
            Destroy(this.gameObject);
            //if (TryGetComponent<Health>(out var health))
            //{
            //    health.ShardDamage(shardDmg);
            //    Destroy(this.gameObject);
            //}
        }
        else
        {
            //Instatiate partical effect here
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
    
}
        
       
    

