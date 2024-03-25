using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Explosion ExplosionPrefab;
    public float Delay = 3f;
    void Start()
    {
        Invoke("Explode", Delay);
    }
    void Explode() {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
