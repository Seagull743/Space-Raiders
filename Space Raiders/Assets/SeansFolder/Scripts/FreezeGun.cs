using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : MonoBehaviour
{
   //m1 gun

    public float damage = 10f;
    public float range = 100f;
    public float firerate = 25f;
    public Camera fpscam;
    public float nexttimetofire = 0f;

    public GameObject projectile;
    public GameObject gunpoint;
    
    public bool shooting;


    //Freeze m2 Var
  
    public GameObject freezebeam;
    public bool Beam;
    private bool freezing = false;
    public int freezespeed = 2;
    public int Slow = 1;
    public static int freezeduration = 5;
    private int unfreezetime;

    public float freezecooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        freezebeam.SetActive(false);
        shooting = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            freezebeam.SetActive(true);
            Beam = true;

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            freezebeam.SetActive(false);
            Beam = false;
        }

        if (Input.GetKey(KeyCode.Mouse1) && !Beam && Time.time >= nexttimetofire)
        {
           nexttimetofire = Time.time + 1f/firerate;
           Shoot();
           shooting = true;
        }
        else
        {
            shooting = false;
        }
       
         
        if(freezing)
        {
            if (unfreezetime > 0)
            {
                StartFreezing();
                //Put Enemy FUnction Here
            }
            else if(unfreezetime <= 0)
            {
               UnFreezing();
               //Enemy Normal
            }
        }

    }
        private void StartFreezing()
        {
            freezing = true;
            unfreezetime = freezeduration;
        }
        private void UnFreezing()
        {
            freezing = false;
            Slow = 1;
            unfreezetime = 0;
   
        }

        private void OnParticleTrigger()
        {
            StartFreezing();
        }



        void Shoot()
    {
        RaycastHit hit;
 
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            // instantiate the bullet
            Debug.Log(hit.transform.name);


        
            
        }
    }
}


