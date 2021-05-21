using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertCollider : MonoBehaviour
{
    [SerializeField]
    float radius;

    [SerializeField]
    LayerMask Enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(this.transform.position, radius, Enemy);

        foreach(var enemyInRange in enemiesInRange)
        {
            Debug.Log("Alerted " + enemyInRange);
            enemyInRange.GetComponent<EnemyAI>().GoToPos();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
