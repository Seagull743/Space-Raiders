﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : MonoBehaviour
{
   //m1 gun

    [SerializeField]
    private float range;
    [SerializeField]
    private float firerate = 25f;
    [SerializeField]
    private Camera fpscam;
    [SerializeField]
    private float nexttimetofire = 0f;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject gunpoint;
    
    private bool shooting;

    [SerializeField]
    private Animator anim;

    public GunAnimations GA;

    public bool freezeon;

    //Freeze m2 Var

    [SerializeField]
    private ParticleSystem freezebeam;
    [SerializeField]
    private GameObject colliderBeam;
    private bool Beam;
    public GameObject[] enemys;
    public GameObject[] platforms;

    [SerializeField]
    private GameObject crossCircle;
    [SerializeField]
    private GameObject crossShard;
    [SerializeField]
    private ParticleSystem muzzleFlash;
    [SerializeField]
    private GameObject FreezeVials;
    [SerializeField]
    private GameObject ShardVials;

    //JET Variables

    public Vector3 lastKnownPos;


    //Paused variables:
    private bool inPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        EnergyGun.EnergyPickedUp = false;
        FreezeVials.SetActive(true);
        ShardVials.SetActive(false);
        crossCircle.SetActive(true);
        crossShard.SetActive(false);
        freezeon = true;
        freezebeam.Stop();
        shooting = false;
        colliderBeam.GetComponent<Collider>().enabled = false;
       // anim = GetComponentInChildren<Animator>();      
    }
    // Update is called once per frame
    void Update()
    {
        if (inPlay == true)
        {


        if (Input.GetKeyDown(KeyCode.R) && !Beam && EnergyGun.EnergyPickedUp == true)
        {
            if (freezeon)
            {
                FindObjectOfType<AudioManager>().Play("gunSwitch");
                FreezeVials.SetActive(false);
                ShardVials.SetActive(true);
                anim.SetBool("isbeamon", false);
                crossCircle.SetActive(false);
                crossShard.SetActive(true);
                freezeon = false;
            }
            else if (freezeon == false)
            {
                FindObjectOfType<AudioManager>().Play("gunSwitch");
                anim.SetBool("isbeamon", true);
                ShardVials.SetActive(false);
                FreezeVials.SetActive(true);
                freezeon = true;
                crossCircle.SetActive(true);
                crossShard.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && freezeon)
        {
            //FindObjectOfType<AudioManager>().Play("freezeRay");
            freezebeam.Play();
            colliderBeam.GetComponent<Collider>().enabled = true;
            Beam = true;
            GA.GetComponent<GunAnimations>().BeamAnim();

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            freezebeam.Stop();
            colliderBeam.GetComponent<Collider>().enabled = false;
            Beam = false;
            GA.GetComponent<GunAnimations>().BeamAnimoff();
            foreach (GameObject e in enemys)
            {
                // e.GetComponent<Freeze>().UnFreezing();
                
                if (TryGetComponent<Freeze>(out var freeze))
                {
                    freeze.UnFreezing();
                }
                
            }
            foreach (GameObject p in platforms)
            {
                p.GetComponent<Freeze>().UnFreezing();
            }
        }


        if (Input.GetKey(KeyCode.Mouse0) && !freezeon && !Beam && Time.time >= nexttimetofire)
        {
            FindObjectOfType<AudioManager>().Play("playerGunFire");
            nexttimetofire = Time.time + 1f / firerate;
            //Gets position of Gun -- JET
            lastKnownPos = this.transform.position;         
            Shoot();
            shooting = true;
           // StartCoroutine(AbleToShoot());
        }
        else
        {
            shooting = false;
        }

        }

    }


    //IEnumerator AbleToShoot()
    //{
   //     yield return new WaitForSeconds(4f);
    //    shooting = false;
   // }

    public void Shoot()
    {
        RaycastHit hit;
        muzzleFlash.Play();

        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            GameObject tempProjectile = Instantiate(projectile, gunpoint.transform.position, gunpoint.transform.rotation);
            GA.GetComponent<GunAnimations>().Shardrecoil();
            tempProjectile.GetComponent<Projectile>().hitpoint = hit.point;   
        }
        else
        {
            GameObject tempProjectile = Instantiate(projectile, gunpoint.transform.position, gunpoint.transform.rotation);
            tempProjectile.GetComponent<Projectile>().hitpoint = fpscam.transform.position + fpscam.transform.forward * range;
            GA.GetComponent<GunAnimations>().Shardrecoil();
        } 
    }

    public void PauseON()
    {
        inPlay = false;
    }

    public void PauseOFF()
    {
        inPlay = true;
    }

}


