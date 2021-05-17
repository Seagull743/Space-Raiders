using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject projectile;
    public bool isFiring;
    public float fireRate;
    public Transform firePoint;

    private void Firing()
    {
        if (isFiring == true)
            StartCoroutine("Fire", fireRate);
    }

    IEnumerator Fire(float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
        Instantiate(projectile, firePoint);
    }
}
