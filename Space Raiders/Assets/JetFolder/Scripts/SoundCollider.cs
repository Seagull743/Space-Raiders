using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{
    [SerializeField]
    float radius;

    [SerializeField]
    LayerMask Enemy;

    public bool alert;

    // Start is called before the first frame update
    void Start()
    {
        alert = GetComponent<EnemyAI>().alerted;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(this.transform.position, radius, Enemy);

        foreach(var enemyInRange in enemiesInRange)
        {
            alert = true;
        }
    }
}
