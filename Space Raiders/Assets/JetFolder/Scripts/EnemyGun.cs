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

    private void Update()
    {
        if (isFiring == true && alreadyFired == false)
            Fire();
    }

    private void Fire()
    {
        Debug.Log("Shot Fired");
        if(alreadyFired != true)
        {
            alreadyFired = true;
            Instantiate(projectile, firePoint.position, firePoint.transform.rotation);
        }  
    }
}
