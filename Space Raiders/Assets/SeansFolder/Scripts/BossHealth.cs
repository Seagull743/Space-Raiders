using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;
    public static bool BossKilled = false;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {

        //HealthBar.fillAmount = currenthealth / maxHealth;



        if (currenthealth <= 0)
        {
            Destroy(this.gameObject);
            BossKilled = true;
        }

    }

    public void RespawnEnemy()
    {
        currenthealth = maxHealth;
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public void ShardDamage(int damageAmount)
    {
        currenthealth -= damageAmount;  
    }


}
