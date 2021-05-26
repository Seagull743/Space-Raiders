using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject projectile;
    public bool isFiring;
    public Transform firePoint;
    public bool alreadyFired;
    [SerializeField]
    private float fireRate;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (isFiring == true && alreadyFired == false)
            StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Shot Fired");
        if(alreadyFired != true)
        {
            alreadyFired = true;
            anim.SetTrigger("attacktrigger");
            yield return new WaitForSeconds(0.5f);
            Instantiate(projectile, firePoint.position, firePoint.transform.rotation);
        }  
    }
}
