using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class MeleeAI : MonoBehaviour
{
    private NavMeshAgent nav;
    [SerializeField]
    private NPCState npcState = NPCState.idle;

    public GameObject Player;

    [SerializeField]
    float wanderDist = 10f;

    public bool seenPlayer;
    public float speed;

    public enum NPCState
    {
        idle,
        wander,
        chase,
        attack,
    }

    void Update()
    {
        switch (npcState)
        {
            case NPCState.idle:
                Idle();

                break;
            case NPCState.wander:
                Wander();

                break;
            case NPCState.chase:
                Chase();

                break;
            case NPCState.attack:
                Attack();
                break;

            default:
                break;

        }
    }

    void Idle()
    {
        if(seenPlayer == false)
        {

        }
    }

    void Wander()
    {
        if(seenPlayer == false)
        {

        }
    }

    void Chase()
    {
        if(seenPlayer == true)
        {

        }
    }

    void Attack()
    {

    }

    void Death()
    {

    }
}
