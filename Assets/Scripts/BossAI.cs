using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public Transform Player;
    public List<Renderer> BodyParts;
    public Animator animator;
    AudioSource _audioSource;
    PlayerHealth _playerHealth;
    NavMeshAgent _navMeshAgent;
    public float Health = 540000f;
    public Transform Caster;
    public GameObject Grenade;
    public float Force = 1f;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
            i.material.color = Color.Lerp(new Color(1f, 0, 0, i.material.color.a), new Color(0.75f, 0.75f, 0.75f, i.material.color.a), Health / 250000f);
        }
    }
    public void DealAttack() {
        var grena = Instantiate(Grenade, Caster.position, Quaternion.identity);
        _audioSource.Play();
        grena.GetComponent<Rigidbody>().AddForce(transform.forward * Force * Random.Range(0.1f, 2f));
    }
    void DieCheck() {
        if (Health <= 0) {
            Destroy(gameObject);
            Player.GetComponent<KillCounter>().Kills++;
            Player.GetComponent<Progress>().AddProgress(25f);
        }
    }
    public void AttackAnim() {
        DealAttack();
    }
}
