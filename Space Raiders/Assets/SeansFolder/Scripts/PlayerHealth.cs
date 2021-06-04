﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

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

    [SerializeField]
    private Animator damageAnim;

    private bool isTakingDmg = false;
    private bool isRegeningHealth;

    public float damagetoplayer = 20;
    [SerializeField]
    private float damagetoplayerBoss;

    [SerializeField]
    private Animator fadeAnim;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {   
        currenthealth = maxHealth;
        unAccomplished.SetActive(false);
        playerLives = 3;
    }

    // Update is called once per frame
    
    
    void FixedUpdate()
    {
        if(currenthealth <= 0)
        {        
             currenthealth = 0;
             GameAnalytics.NewDesignEvent("Death:Mob");
             fadeAnim.SetBool("out", true);
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
        damageAnim.SetTrigger("dmg");
        Invoke("TakingDamageFalse", 3);

    }

    public void TakeDamageBoss()
    {
        currenthealth -= damagetoplayerBoss;
        isTakingDmg = true;
        damageAnim.SetTrigger("dmg");
        Invoke("TakingDamageFalse", 3);

    }

    public void RespawnPlayer()
    {
        
        playerLives -= 1;
        gameManager.SpawnPlayer();
        fadeAnim.SetBool("in", true);
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
            HealthBar.value = 0;
            healthText.text = 0 + "/100";
            Invoke("Youlost", 5);
        }
    }

    private void Youlost()
    {
        unAccomplished.SetActive(false);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Game");
        SceneManager.LoadScene("Lose");
        Cursor.lockState = CursorLockMode.None;
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

