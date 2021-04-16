using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : MonoBehaviour
{
    public GameObject freezebeam;
    public bool freezing;
    public Rigidbody projectile;
    public Transform gunpoint;
    public LayerMask ground;

    
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
            freezing = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            freezebeam.SetActive(false);
            freezing = false;
        }


        if (Input.GetKeyDown(KeyCode.Mouse1) && !freezing)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, gunpoint.position, gunpoint.rotation) as Rigidbody;
            projectileInstance.AddForce(gunpoint.forward * 4000f);


        }
    }

}
