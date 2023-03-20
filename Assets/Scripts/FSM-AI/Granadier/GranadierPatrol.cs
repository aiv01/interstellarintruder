using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierPatrol : State
{
    public GranadierPatrol(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats) : base(_entity, _agent, _anim, _player, _stats)
    {
        stateType = STATE.Patrol;
        agent.speed = stats.speed;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        anim.SetBool("InPursuit", true);
        float lastDistance = Mathf.Infinity;
        //Recupero patrol point
        base.Enter();
    }

    public override void Update()
    {
        if(agent.remainingDistance < 1)
        {
            //cambio waipoint
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
        base.Update();
    }
    public override void Exit()
    {
        anim.SetBool("InPursuit", false);
        base.Exit();
    }
}
