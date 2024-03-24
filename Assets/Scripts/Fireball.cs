using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Lifetime = 5f;
    public float Damage = 25f;
    public float Speed = 1f;
    public GameObject EnemyPrefab;
    void Start()
    {
        Invoke("DestroyBall", Lifetime);
    }
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
    void DestroyBall() {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy" && other.gameObject.tag != "collider") {
            other.gameObject.GetComponent<EnemyAI>().DealDamage(Damage);
            DestroyBall();
        }
        else if (other.gameObject.tag != "enemy" && other.gameObject.tag != "collider") {
            DestroyBall();
        }
    }
}
