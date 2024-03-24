using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public EnemyAI enemy;

    void OnTriggerEnter(Collider other)
    {
        enemy.IsAttacking = true;
    }
    void OnTriggerExit(Collider other)
    {
        enemy.IsAttacking = false;
    }
}
