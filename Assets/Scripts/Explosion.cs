using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float MaxSize = 10f;
    public float Speed = 1f;
    public float Damage = 25f;
    void Update()
    {
        if (transform.localScale.magnitude <= MaxSize) {
            transform.localScale += Vector3.one * Time.deltaTime * Speed;
        }
        else { Destroy(gameObject); }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player") {
            other.gameObject.GetComponent<PlayerHealth>().DealDamage(Damage);
        }
    }
}
