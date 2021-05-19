using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;

    [SerializeField]
    private Image EnemyHealthBar;
   
 
    
    // Start is called before the first frame update
    void Start()
    {   
        currenthealth = maxHealth;
        EnemyHealthBar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        EnemyHealthBar.fillAmount = currenthealth / maxHealth;
        
        
        
        if(currenthealth <= 0)
        {
            this.gameObject.SetActive(false);
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
        StartCoroutine(HealthBarIndication());
    }


    IEnumerator HealthBarIndication()
    {
        EnemyHealthBar.enabled = true;
        yield return new WaitForSeconds(3);
        EnemyHealthBar.enabled = false;  
    }

}
