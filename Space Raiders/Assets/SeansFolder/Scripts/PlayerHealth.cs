using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    public float currenthealth;
    public static float playerLives = 3;
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
    [SerializeField]
    private GameObject unAccomplished;


    private bool isTakingDmg = false;
    private bool isRegeningHealth;

    public float damagetoplayer = 20;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {   
        currenthealth = maxHealth;
        unAccomplished.SetActive(false);
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
    
       if(Input.GetKeyDown(KeyCode.P))
       {
           currenthealth -= 20;
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

    public void TakeDamage()
    {
        currenthealth -= damagetoplayer;
        isTakingDmg = true;
        Invoke("TakingDamageFalse", 3);

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
            unAccomplished.SetActive(true);
            Invoke("Youlost", 8);
        }
    }

    private void Youlost()
    {
        unAccomplished.SetActive(false);
        SceneManager.LoadScene("MainMenu-Final");
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

