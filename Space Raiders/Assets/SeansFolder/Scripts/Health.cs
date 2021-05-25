using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;

    [SerializeField]
    private Image HealthBar;
   
 
    
    // Start is called before the first frame update
    void Start()
    {   
        currenthealth = maxHealth;
        HealthBar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        HealthBar.fillAmount = currenthealth / maxHealth;
        
        
        
        if(currenthealth <= 0)
        {
            //do the death animation
            Invoke("DeathAninmation", 4);
        }
    
    }

    public void DeathAninmation()
    {
        this.gameObject.SetActive(false);
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
        StartCoroutine(HealthBarIndication());
    }


    IEnumerator HealthBarIndication()
    {
        HealthBar.enabled = true;
        yield return new WaitForSeconds(3);
        HealthBar.enabled = false;  
    }

}
