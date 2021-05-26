using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginFade : MonoBehaviour
{
    [SerializeField] Animator anim = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        anim.SetBool("in", true);
    }
  

    public void FadeOut()
    {
        anim.SetBool("out", true);
        anim.SetBool("in", false);
    }

    public void FadeOutOff()
    {
        anim.SetBool("out", false);
    }
}
