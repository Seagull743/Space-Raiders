using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float maxLifeTime;
    public float currentLifeTime;
    public int damage;

    private void Start()
    {
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
            GameObject.Find("Player").GetComponent<Health>().currenthealth -= damage;
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
