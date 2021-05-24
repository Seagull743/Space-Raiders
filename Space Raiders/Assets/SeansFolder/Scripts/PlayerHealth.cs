using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    public float currenthealth;

    [SerializeField]
    public float playerLives = 3;
    [SerializeField]
    private GameObject heart1;
    [SerializeField]
    private GameObject heart2;
    [SerializeField]
    private GameObject heart3;
    [SerializeField]
    private Slider HealthBar;
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
        HealthBar.value = currenthealth / maxHealth;
        healthText.text = currenthealth + "/100";

        if(!isTakingDmg && currenthealth != maxHealth && !isRegeningHealth)
        {
            StartCoroutine(RegainHealthOverTime());
        }
    
       // if(Input.GetKeyDown(KeyCode.P))
       //{
        //    currenthealth -= 20;
        //    isTakingDmg = true;
       //     Invoke("TakingDamageFalse", 5);
       // }      
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

    public void RespawnPlayer()
    {
        playerLives -= 1;
        gameManager.SpawnPlayer();
        currenthealth = maxHealth;
        Debug.Log("Spawned");
        isTakingDmg = true;

        if(playerLives == 2)
        {
            heart3.SetActive(false);
        }
        else if(playerLives == 1)
        {
            heart2.SetActive(false);
        }
        else if(playerLives == 0)
        {
            heart1.SetActive(false);
            Debug.Log("You lost");
            //Load the main Menu
        }
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

