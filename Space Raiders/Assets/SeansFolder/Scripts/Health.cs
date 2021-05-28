using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;

    private bool death = false;


    [SerializeField]
    private Image HealthBar;

    private Animator anim;

    [SerializeField]
    private AudioSource hurt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currenthealth = maxHealth;
        HealthBar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = currenthealth / maxHealth;    
        
        if(currenthealth <= 0 && !death)
        {
            StartCoroutine("Death");
        }
    }

    IEnumerator Death()
    {
        death = true;
        yield return new WaitForSeconds(0.1f);
        anim.SetTrigger("deathtrigger");
        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(false);
    }


    public void RespawnEnemy()
    {
        currenthealth = maxHealth;
        death = false;
        GetComponent<EnemyAI>().isDead = false;
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

    public void HurtSound()
    {
        hurt.Play();
    }

    IEnumerator HealthBarIndication()
    {
        HealthBar.enabled = true;
        yield return new WaitForSeconds(3);
        HealthBar.enabled = false;  
    }

}
