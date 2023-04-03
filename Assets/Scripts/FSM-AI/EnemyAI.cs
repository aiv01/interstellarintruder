using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Weapon.Projectile;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    State currentState;
    public Transform player;
    public GranadierStats stats;
    public List<Transform> waypoints;
    public float currentHp;
    public bool Hitted = false;
    public IsaacTileInfo myTile;
    public NavMeshAgent Agent
    {
        get { if(agent == null) { agent = GetComponent<NavMeshAgent>(); } return agent; }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        gameObject.SetActive(false) ;
    }

    private void OnEnable()
    {
        currentState = new GranadierIdle(gameObject, agent, anim, player, stats, this);
        currentHp = stats.healthPoint;
        if (player == null) player = GameObject.Find("Ellen").transform;
    }

    private void OnDisable()
    {
        currentState = null;
        currentHp = -1;
    }

    private void Update()
    {
        currentState = currentState.Process();
    }

}
