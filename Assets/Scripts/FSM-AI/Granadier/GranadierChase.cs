using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierChase : State
{
    public GranadierChase(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats) : base(_entity, _agent, _anim, _player, _stats)
    {
        stateType = STATE.Chase;
        agent.speed = stats.chaseSpeed;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        Debug.Log("Enter Chase");
        anim.SetBool("InPursuit",true);
        base.Enter();
    }
    public override void Update()
    {
        
        agent.SetDestination(player.position);

        if (agent.hasPath)
        {
            if (CanMeleePlayer())
            {
                nextState = new GranadierMeleeAttack(entity, agent, anim, player, stats);
                stage = EVENT.Exit;
            }else if (CanShootPlayer())
            {
                nextState = new GranadierRangeAttack(entity, agent, anim, player, stats);
                stage = EVENT.Exit;
            } else if(!CanSeePlayer())
            {
                nextState = new GranadierPatrol(entity, agent, anim, player, stats);
                stage = EVENT.Exit;
            }

        }
    }
    public override void Exit()
    {
        Debug.Log("Exit Chase");
        agent.isStopped = true;
        anim.SetBool("InPursuit", false);
        base.Exit();
    }

}
