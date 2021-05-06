using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimations : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    public void BeamAnim()
    {
        anim.SetBool("isBeam", true);
    }

    public void BeamAnimoff()
    {
        anim.SetBool("isBeam", false);
    }

    public void ShardDown()
    {
        anim.SetBool("isShooting", false);
    }

    public void Shardrecoil()
    {
        anim.SetBool("isShooting", true);
        Invoke("ShardDown", 1);
    }
}
