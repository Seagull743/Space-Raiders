using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 hitpoint;

    public float shardDmg = 20;

    public int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitpoint - this.transform.position).normalized * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //this is where i would put the hit effect
            collision.gameObject.GetComponent<Health>().currenthealth -= 20;
            Destroy(this.gameObject);
        }
        else
        {
            //Instatiate partical effect here
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
    
}
        
       
    

