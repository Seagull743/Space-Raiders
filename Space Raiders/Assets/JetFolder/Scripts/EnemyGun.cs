using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject projectile;
    public bool isFiring;
    public Transform firePoint;
    public bool alreadyFired;

    private void Update()
    {
        if (isFiring == true)
            Fire();
    }

    private void Fire()
    {
        Debug.Log("Shot Fired");
        Instantiate(projectile, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
