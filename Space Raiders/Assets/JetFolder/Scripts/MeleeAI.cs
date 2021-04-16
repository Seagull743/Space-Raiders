using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class MeleeAI : MonoBehaviour
{
    public GameObject player;

    public float damage;
    public float speed;
    public bool seenPlayer;

    [SerializeField] float viewRadius;
    [SerializeField] float eyeHeight = 3.65f;
    [Range(0, 360)]
    [SerializeField] float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [SerializeField] List<Transform> playerTracker = new List<Transform>();
    public List<Collider> thingsIThinkICanSee = new List<Collider>();
    public List<Transform> thingsICanSee = new List<Transform>();

    [SerializeField] private Vector3 lastKnownPos;
    [SerializeField] Color sightColour = new Color(207, 169, 255, 255);
    private float distanceToLastKnownPos;

    private NavMeshAgent nav;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Look()
    {
        playerTracker.Clear();
        thingsIThinkICanSee.Clear();
        thingsICanSee.Clear();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position + new Vector3(0, eyeHeight, 0), viewRadius, targetMask);
        foreach (Collider c in targetsInViewRadius)
        {
            thingsIThinkICanSee.Add(c);
        }

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            playerTracker.Clear();
            thingsICanSee.Clear();

            //Transform player = targetsInViewRadius[i].transform;
            Transform playerTargetPoint = player.transform;

            Vector3 dirToTarget = (playerTargetPoint.position - (transform.position - transform.forward)).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {

                float dist = Vector3.Distance(transform.position + new Vector3(0, eyeHeight, 0), playerTargetPoint.position);
                if (!Physics.Raycast((transform.position + new Vector3(0, eyeHeight, 0)) - transform.forward, dirToTarget, out hit, dist, obstacleMask))
                {
                    playerTracker.Add(playerTargetPoint);
                    thingsICanSee.Add(playerTargetPoint);
                    lastKnownPos = playerTargetPoint.position;
                    distanceToLastKnownPos = dist;
                    seenPlayer = true;
                    //Debug.DrawLine(transform.position + new Vector3(0, eyeHeight, 0), hit.point, Color.green);
                }

                else
                {
                    playerTracker.Clear();
                    thingsICanSee.Clear();
                    thingsIThinkICanSee.Clear();
                    Debug.DrawLine(transform.position + new Vector3(0, eyeHeight, 0), hit.point, Color.blue);
                }
            }
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.rotation.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 eyePos = transform.position;
        eyePos.y += eyeHeight;

        Gizmos.color = sightColour;
        //Gizmos.DrawWireSphere(eyePos, sightRange);
        Handles.color = sightColour;
        Handles.DrawWireArc(eyePos - transform.forward, Vector3.up, Vector3.forward, 360, viewRadius);
        Vector3 viewAngleA = DirectionFromAngle(-viewAngle / 2, false);
        Vector3 viewAngleB = DirectionFromAngle(viewAngle / 2, false);
        Handles.DrawLine(eyePos - transform.forward, eyePos - transform.forward + viewAngleA * viewRadius);
        Handles.DrawLine(eyePos - transform.forward, eyePos - transform.forward + viewAngleB * viewRadius);

        Handles.color = Color.red;
        if (playerTracker.Count > 0)
        {
            Handles.DrawLine(eyePos, playerTracker[0].position);
        }
    }
}
