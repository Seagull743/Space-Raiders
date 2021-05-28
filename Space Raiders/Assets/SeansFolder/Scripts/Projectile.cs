using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 hitpoint;

    public int shardDmg = 20;
    public int frozenDmg = 50;

    public int speed;

    
    public float currentLifeTime;

    [SerializeField]
    private GameObject impact;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLifeTime = 8;


        this.GetComponent<Rigidbody>().AddForce((hitpoint - this.transform.position).normalized * speed);
    }

    void Update()
    {
        currentLifeTime -= Time.deltaTime;

       if(currentLifeTime <= 0)
        {
            Destroy(this.gameObject);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Range" || collision.gameObject.tag == "Melee")
        {
            collision.gameObject.GetComponent<Health>().HurtSound();
            collision.gameObject.GetComponent<Health>().ShardDamage(shardDmg);
            GameObject newImpact = (Instantiate(impact, this.transform.position, this.transform.rotation));     
            Destroy(this.gameObject);       
        }
        else if(collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<BossHealth>().ShardDamage(shardDmg);
            GameObject newImpact = (Instantiate(impact, this.transform.position, this.transform.rotation));
            Destroy(this.gameObject);
        }     
        else
        {
            Instantiate(impact, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }

}
        
       
    

