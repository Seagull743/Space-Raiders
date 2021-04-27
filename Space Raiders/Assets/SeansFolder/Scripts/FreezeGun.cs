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
            nexttimetofire = Time.time + 1f / firerate;
            Shoot();
            shooting = true;
        }
        else
        {
            shooting = false;
        }

    }
        
        


        void Shoot()
    {
        RaycastHit hit;
 
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            GameObject tempProjectile = Instantiate(projectile, gunpoint.transform.position, gunpoint.transform.rotation);
            tempProjectile.GetComponent<Projectile>().hitpoint = hit.point;
            Debug.Log(hit.transform.name);      
            
        }
        
    }
}


