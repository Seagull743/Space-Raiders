using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : MonoBehaviour
{
    public GameObject freezebeam;
    public bool Beam;
    public Rigidbody projectile;
    public Transform gunpoint;
    public LayerMask ground;

    //Freeze Var
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

        if (Input.GetKeyDown(KeyCode.Mouse1) && !Beam)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, gunpoint.position, gunpoint.rotation) as Rigidbody;
            projectileInstance.AddForce(gunpoint.forward * 4000f);

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



}
