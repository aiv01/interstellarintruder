using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    State currentState;

    public Transform player;
    public GranadierStats stats;

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
}
