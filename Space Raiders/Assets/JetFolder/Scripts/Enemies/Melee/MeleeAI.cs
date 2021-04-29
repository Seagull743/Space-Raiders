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

    public Transform player;

    [SerializeField]
    float wanderDist = 10f;

    bool seenPlayer;

    float walkSpeed = 1f;
    float runSpeed = 5f;
    float closeToPlayerSpeed = 3f;

    float damage;

    float distToPlayer;

    float radius;

    [Range(0, 360)]
    [SerializeField] float viewAngle;
    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstacleMask;
    public List<Transform> visibleTargets = new List<Transform>();

    [SerializeField] private Vector3 lastKnownPos;
    [SerializeField] Color sightColour = new Color(207, 169, 255, 255);

    Rigidbody rb;

    RaycastHit hit;

    private void Start()
    {
        nav.speed = walkSpeed;
    }

    public enum NPCState
    {
        idle,
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

    }

    void Chase()
    {
        float distToPlayer = Vector3.Distance(player.position, transform.position);

        if (seenPlayer == true && distToPlayer >= 20f)
        {
            nav.speed = runSpeed;
        }
    }

    void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (var hitCollider in hitColliders)
        {
            if (seenPlayer == true && distToPlayer <= 3f)
            {

            }
        }
    }

    void Death()
    {

    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.rotation.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
