using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public EnemyAI enemy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player") enemy.IsAttacking = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player") enemy.IsAttacking = false;
    }
}
