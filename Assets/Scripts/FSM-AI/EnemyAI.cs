using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Weapon.Projectile;

public class EnemyAI : MonoBehaviour
{
    public delegate void EnemyDelegate(EnemyAI enemyDeath);
    public event EnemyDelegate OnDeath = null;

    NavMeshAgent agent;
    Animator anim;
    State currentState;

    public Transform player;
    public GranadierStats stats;
    public List<Transform> waypoints;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentState = new GranadierIdle(gameObject, agent, anim, player,stats);
    }

    private void Update()
    {
        currentState = currentState.Process();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (stats.healthPoint <= 0)
            Die();
    }

    private void Die()
    {
        OnDeath?.Invoke(this);
    }
}
