using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource footSteps;

    [SerializeField]
    private AudioSource roar;

    [SerializeField]
    private Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && anim != null)
            anim.SetTrigger("roar");         
    }

    private void PlayFootsteps()
    {
        if(footSteps != null)
            footSteps.Play();
    }

    private void PlayRoar()
    {
        if(roar != null)
            roar.Play();
    }
}
