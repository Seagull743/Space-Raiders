using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bulletTarget;
    public float speed;
    public float maxLifeTime;
    public float currentLifeTime;

    private void Awake()
    {
        bulletTarget = GameObject.Find("BulletTarget").transform;
    }

    private void Start()
    {
        transform.LookAt(bulletTarget);

        currentLifeTime = maxLifeTime;
    }

    void Update()
    {
        currentLifeTime -= Time.deltaTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        currentLifeTime = Mathf.Clamp(currentLifeTime, 0, maxLifeTime);

        if (currentLifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage();
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
