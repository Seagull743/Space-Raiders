using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currenthealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    public void ShardDamage()
    {
        currenthealth -= 20;
    }

}
