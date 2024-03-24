using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public List<Renderer> BodyParts;
    public Animator animator;
    PlayerHealth _playerHealth;
    NavMeshAgent _navMeshAgent;
    public float Health = 100f;
    public float Damage;
    public bool IsAttacking; 

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = Player.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        _navMeshAgent.SetDestination(Player.position);
        if (IsAttacking) {
            animator.SetTrigger("Attack");
        }
        DieCheck();
    }
    public void DealDamage(float damage) {
        Health -= damage;
        foreach (Renderer i in BodyParts) {
            i.material.color = Color.Lerp(Color.black, i.material.color, Health / 100f);
        }
    }
    public void DealAttack() {
        if (IsAttacking) {
            _playerHealth.DealDamage(Damage);
        }
    }
    void DieCheck() {
        if (Health <= 0) {
            Destroy(gameObject);
            Player.GetComponent<PlayerHealth>().Kills++;
            Player.GetComponent<Progress>().AddProgress(25f);
        }
    }
    public void AttackAnim() {
        DealAttack();
    }
}
