using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : MonoBehaviour
{
   //m1 gun

    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private float range = 100f;
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
    public bool freezeon;

    //Freeze m2 Var

    [SerializeField]
    private ParticleSystem freezebeam;
    [SerializeField]
    private  GameObject colliderBeam;
    private bool Beam;
    public GameObject[] enemys;
    public GameObject[] platforms;

    // Start is called before the first frame update


    void Start()
    {
        freezeon = true;
        freezebeam.Stop();
        shooting = false;
        colliderBeam.GetComponent<Collider>().enabled = false;
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && !Beam)
        {
            if (freezeon)
            {
                anim.SetBool("isbeamon", false);
                freezeon = false;
            }
            else if (freezeon == false)
            {
                anim.SetBool("isbeamon", true);
                freezeon = true;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && freezeon)
        {
            freezebeam.Play();
            colliderBeam.GetComponent<Collider>().enabled = true;
            Beam = true;

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            freezebeam.Stop();
            colliderBeam.GetComponent<Collider>().enabled = false;
            Beam = false; 
            foreach (GameObject e in enemys)
            {
                e.GetComponent<Freeze>().UnFreezing();
            }
            foreach (GameObject p in platforms)
            {
                p.GetComponent<Freeze>().UnFreezing();
            }
        }


        if (Input.GetKey(KeyCode.Mouse1) && !freezeon && !Beam && Time.time >= nexttimetofire)
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
    public void Shoot()
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


