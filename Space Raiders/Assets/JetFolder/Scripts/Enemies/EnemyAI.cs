using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool melee = false;
    public bool range = false;
    public bool boss = false;

    private Animator anim;

    public NavMeshAgent nav;

    public Transform player;

    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float runSpeed = 4f;

    [SerializeField] float timeBetweenAttacks;
	[SerializeField] float attackDelay;
    public bool playerInSightRange, playerInAttackRange;	
	public bool attacking;
	public bool alerted;
	public bool isFrozen;
	public bool isDead = false;

	public GameObject damageBox;

	public Vector3 storedPos;

	public float attackRange;

	[HideInInspector]
	public Health health;

	//FOV variables
	public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public float meshResolution;
    public int edgeResolveIterations;
    public float edgeDstThreshold;

    public float maskCutawayDst = .1f;

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		health = GetComponent<Health>();

    }

    void Start()
    {
		if(damageBox !=null)
			damageBox.SetActive(false);
		
        if (this.gameObject.tag == "Melee")
            melee = true;

        if (this.gameObject.tag == "Range")
            range = true;

        if (this.gameObject.tag == "Boss")
            boss = true;

		if(melee != false && boss != false && range != true && !damageBox)
			Debug.LogWarning("No Damage Box Assigned on Melee/Boss Enemy");

		if(viewMeshFilter != null)
        {
			viewMesh = new Mesh();
			viewMesh.name = "View Mesh";
			viewMeshFilter.mesh = viewMesh;
		}
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    void Update()
    {
		//playerInSightRange = Physics.CheckSphere(transform.position, sightRange, targetMask);
		//playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, targetMask);

		if (!playerInSightRange && !playerInAttackRange && !isDead) nav.speed = walkSpeed;
        if (playerInSightRange && !playerInAttackRange && !isDead && !isFrozen && melee || playerInSightRange && !playerInAttackRange && !isDead && !isFrozen && boss) Chase();
        if (playerInAttackRange && playerInSightRange && !isDead && !isFrozen) Attack();
		
		if (melee != false && !isDead || boss != false && !isDead)
		{
			if (playerInSightRange && !playerInAttackRange)
			{
				anim.SetBool("walk", true);
			}
			
			if(!playerInSightRange && playerInAttackRange || !playerInSightRange && !playerInAttackRange)
			{
				anim.SetBool("walk", false);
			}
		}
 
		if(melee && health.currenthealth <= 0 || range && health.currenthealth <= 0)
        {
			isDead = true;
			nav.speed = 0;
        }
	}

	public void GoToPos()
    {
		if(melee != false)
        {
			storedPos = player.GetComponentInChildren<FreezeGun>().lastKnownPos;
			nav.SetDestination(storedPos);
		}		
    }

    private void Chase()
    {
		if(!attacking && !isDead && !isFrozen)
        {
			nav.speed = runSpeed;
			nav.SetDestination(player.position);
		}		
	}

	private void Attack()
	{
		Debug.Log("Damage Player");
		
		Vector3 targetPosition = new Vector3(player.position.x, this.transform.position.y, player.position.z);

		if (!isFrozen && !isDead)
			this.transform.LookAt(targetPosition);

		if (!attacking && (melee || boss) && !range)
        {
			anim.SetTrigger("attacktrigger");
		}

        if ((!attacking && melee != false && !isFrozen && !isDead) || (!attacking && boss != false && !isFrozen && !isDead))
		{
			nav.SetDestination(transform.position);
			attacking = true;
			Invoke(nameof(StartAttack), attackDelay);
		}

		if (!attacking && range != false && !isFrozen && !isDead)
        {
			GetComponentInChildren<EnemyGun>().isFiring = true;
			attacking = true;
			Invoke(nameof(StartAttack), attackDelay);
        }
	}

	private void StartAttack()
	{
		if (damageBox != null && !isFrozen)
        {
			damageBox.SetActive(true);
		}		
		Invoke(nameof(ResetAttack), timeBetweenAttacks);
	}

    private void ResetAttack()
    {	
		if(damageBox != null && !isFrozen)
        {
			damageBox.SetActive(false);
		}	

		if(range != false)
        {
			GetComponentInChildren<EnemyGun>().isFiring = false;
			GetComponentInChildren<EnemyGun>().alreadyFired = false;
        }
		attacking = false;
    }

	public void Frozen()
	{
		isFrozen = true;

		FindObjectOfType<AudioManager>().Play("frozen");

		if (boss)
			anim.speed = 0.3F;
			nav.speed = 0.3F;
		
        if(melee || range)
			anim.speed = 0;
			nav.speed = 0;	
	}

	public void UnFrozen()
	{
		isFrozen = false;
		nav.speed = 1;
		anim.speed = 1;
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    IEnumerator FindTargetsWithDelay(float delay)
	{
		while (true)
		{
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}
	}

	void LateUpdate()
	{
		DrawFieldOfView();
	}

	void FindVisibleTargets()
	{
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        Collider[] targetsInAttackRadius = Physics.OverlapSphere(transform.position, attackRange, targetMask);

		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			Transform target = targetsInViewRadius[i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
			{
				float dstToTarget = Vector3.Distance(transform.position, target.position);
				if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
				{			
					playerInSightRange = true;
					visibleTargets.Add(target);		
				}
			}
		}

        for (int i = 0; i < targetsInAttackRadius.Length; i++)
        {
            Transform target = targetsInAttackRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    playerInAttackRange = true;
                    visibleTargets.Add(target);
                }
            }
        }

        if (targetsInViewRadius.Length == 0)
        {
			playerInSightRange = false;
        }

        if (targetsInAttackRadius.Length == 0)
        {
            playerInAttackRange = false;
        }
    }

	#region FOVMeshDraw
	void DrawFieldOfView()
	{
		int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
		float stepAngleSize = viewAngle / stepCount;
		List<Vector3> viewPoints = new List<Vector3>();
		ViewCastInfo oldViewCast = new ViewCastInfo();
		for (int i = 0; i <= stepCount; i++)
		{
			float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
			ViewCastInfo newViewCast = ViewCast(angle);

			if (i > 0)
			{
				bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
				if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
				{
					EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
					if (edge.pointA != Vector3.zero)
					{
						viewPoints.Add(edge.pointA);
					}
					if (edge.pointB != Vector3.zero)
					{
						viewPoints.Add(edge.pointB);
					}
				}

			}


			viewPoints.Add(newViewCast.point);
			oldViewCast = newViewCast;
		}

		int vertexCount = viewPoints.Count + 1;
		Vector3[] vertices = new Vector3[vertexCount];
		int[] triangles = new int[(vertexCount - 2) * 3];

		vertices[0] = Vector3.zero;
		for (int i = 0; i < vertexCount - 1; i++)
		{
			vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]) + Vector3.forward * maskCutawayDst;

			if (i < vertexCount - 2)
			{
				triangles[i * 3] = 0;
				triangles[i * 3 + 1] = i + 1;
				triangles[i * 3 + 2] = i + 2;
			}
		}

		if(viewMeshFilter != null)
        {
			viewMesh.Clear();

			viewMesh.vertices = vertices;
			viewMesh.triangles = triangles;
			viewMesh.RecalculateNormals();
		}		
	}


	EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
	{
		float minAngle = minViewCast.angle;
		float maxAngle = maxViewCast.angle;
		Vector3 minPoint = Vector3.zero;
		Vector3 maxPoint = Vector3.zero;

		for (int i = 0; i < edgeResolveIterations; i++)
		{
			float angle = (minAngle + maxAngle) / 2;
			ViewCastInfo newViewCast = ViewCast(angle);

			bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > edgeDstThreshold;
			if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
			{
				minAngle = angle;
				minPoint = newViewCast.point;
			}
			else
			{
				maxAngle = angle;
				maxPoint = newViewCast.point;
			}
		}

		return new EdgeInfo(minPoint, maxPoint);
	}


	ViewCastInfo ViewCast(float globalAngle)
	{
		Vector3 dir = DirFromAngle(globalAngle, true);
		RaycastHit hit;

		if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
		{
			return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
		}
		else
		{
			return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
		}
	}

	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

	public struct ViewCastInfo
	{
		public bool hit;
		public Vector3 point;
		public float dst;
		public float angle;

		public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
		{
			hit = _hit;
			point = _point;
			dst = _dst;
			angle = _angle;
		}
	}

	public struct EdgeInfo
	{
		public Vector3 pointA;
		public Vector3 pointB;

		public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
		{
			pointA = _pointA;
			pointB = _pointB;
		}
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, sightRange);
    }
	#endregion
}
