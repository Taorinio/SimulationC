using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public Transform Player;
    public List<Renderer> BodyParts;
    public Animator animator;
    PlayerHealth _playerHealth;
    NavMeshAgent _navMeshAgent;
    public float Health = 540000f;
    public Transform Caster;
    public GameObject Grenade;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = Player.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        _navMeshAgent.SetDestination(Player.position);
        animator.SetTrigger("Attack");
        DieCheck();
    }
    public void DealDamage(float damage) {
        Health -= damage;
        foreach (Renderer i in BodyParts) {
            i.material.color = Color.Lerp(new Color(1f, 0, 0, i.material.color.a), i.material.color, Health / 100f);
        }
    }
    public void DealAttack() {
        Instantiate(Grenade, Caster.position, Quaternion.identity);
    }
    void DieCheck() {
        if (Health <= 0) {
            Destroy(gameObject);
            Player.GetComponent<KillCounter>().Kills++;
            Player.GetComponent<Progress>().AddProgress(1000f);
        }
    }
    public void AttackAnim() {
        DealAttack();
    }
}
