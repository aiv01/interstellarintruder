using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierPatrol : State
{
    int currentIndex;
    List<Transform> waypoints;
    public GranadierPatrol(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats) : base(_entity, _agent, _anim, _player, _stats)
    {
        stateType = STATE.Patrol;
        agent.speed = stats.speed;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        Debug.Log("Enter Patrol");
        anim.SetBool("InPursuit", true);
        float lastDistance = Mathf.Infinity;
        waypoints = entity.GetComponent<EnemyAI>().waypoints;
        for(int i = 0; i < waypoints.Count; i++)
        {
            float distance = Vector3.Distance(entity.transform.position, waypoints[i].transform.position);
            if(distance < lastDistance)
            {
                currentIndex = i;
                lastDistance = distance;
            }
        }
        agent.SetDestination(waypoints[currentIndex].position);
        base.Enter();
    }

    public override void Update()
    {
        
        if (agent.remainingDistance < 1)
        {
           if(currentIndex >= waypoints.Count-1)
            {
                currentIndex = 0;
            } else
            {
                currentIndex++;
            }
            agent.SetDestination(waypoints[currentIndex].position);
        }
        if (Die())
        {
            nextState = new GranadierDie(entity, agent, anim, player, stats);
            stage = EVENT.Exit;
        }

        if (CanSeePlayer())
        {
            nextState = new GranadierChase(entity, agent, anim, player, stats);
            stage = EVENT.Exit;
        } else if (IsPlayerBehind())
        {
            nextState = new GranadierChase(entity, agent, anim, player, stats);
            stage = EVENT.Exit;
        }
        
    }
    public override void Exit()
    {
        Debug.Log("Exit Patrol");
        anim.SetBool("InPursuit", false);
        base.Exit();
    }
}
