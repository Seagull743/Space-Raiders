using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;
    public bool BossKilled = false;
    private Animator anim;
    private AudioSource hurt;

    [SerializeField]
    private Slider BossHealthBar;
    [SerializeField]
    private GameObject BossHealthBackground;
    [SerializeField]
    private GameObject bossText;


    // Start is called before the first frame update
    void Start()
    {
        bossText.SetActive(false);
        BossHealthBackground.SetActive(false);
        BossHealthBackground.SetActive(false);
        
        hurt = GetComponent<AudioSource>();
        currenthealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BossHealthBar.value = currenthealth / maxHealth;
        
        if (currenthealth <= 0 && BossKilled != true)
        {
            BossKilled = true;
            BossHealthBackground.SetActive(false);
            BossHealthBackground.SetActive(false);
            StartCoroutine("DestroyEnemy");         
        }
    }

    public void RespawnEnemy()
    {
        currenthealth = maxHealth;
    }

 
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetTrigger("deathtrigger");
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }    

    public void ShardDamage(int damageAmount)
    {
        currenthealth -= damageAmount;  
    }

    private void HurtSound()
    {
        hurt.Play();
    }
}
