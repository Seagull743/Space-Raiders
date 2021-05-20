using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float currenthealth;

    [SerializeField]
    private Image HealthBar;
    [SerializeField]
    private Text healthText;

    private bool isTakingDmg = false;
    private bool isRegeningHealth;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {   
        currenthealth = maxHealth;
    }

    // Update is called once per frame
    
    
    void FixedUpdate()
    {
        if(currenthealth <= 0)
        {
            RespawnPlayer();         
        }
    }
    
    void Update()
    {
        
        HealthBar.fillAmount = currenthealth / maxHealth;
        healthText.text = currenthealth + "/100";

        if(!isTakingDmg && currenthealth != maxHealth && !isRegeningHealth)
        {
            StartCoroutine(RegainHealthOverTime());
        }
    
        if(Input.GetKeyDown(KeyCode.P))
        {
            currenthealth -= 20;
            isTakingDmg = true;
            Invoke("TakingDamageFalse", 5);
        }      
    
    }  

    private IEnumerator RegainHealthOverTime()
    {
        isRegeningHealth = true;
        while (currenthealth < maxHealth && !isTakingDmg)
        {
            HealthRegen();
            yield return new WaitForSeconds(1);
        }
        isRegeningHealth = false;
    }

    private void RespawnPlayer()
    {
        gameManager.SpawnPlayer();
        currenthealth = maxHealth;
        Debug.Log("Spawned");
        isTakingDmg = true;
    }

    private void HealthRegen()
    {
        currenthealth += 2;
    }

    private void TakingDamageFalse()
    {
        isTakingDmg = false;
    }

}

