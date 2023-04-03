using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierChase : State
{
    public GranadierChase(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats, EnemyAI _enemy) : base(_entity, _agent, _anim, _player, _stats, _enemy)
    {
        stateType = STATE.Chase;
        agent.speed = stats.chaseSpeed;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        anim.SetBool("InPursuit",true);
        base.Enter();
    }
    public override void Update()
    {
        
        agent.SetDestination(player.position);
        if (Die())
        {
            nextState = new GranadierDie(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        }
        else if (Hit())
        {
            nextState = new GranadierHit(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        }
        if (agent.hasPath)
        {
            if (CanMeleePlayer())
            {
                nextState = new GranadierMeleeAttack(entity, agent, anim, player, stats, enemy);
                stage = EVENT.Exit;
            }else if (CanShootPlayer())
            {
                nextState = new GranadierRangeAttack(entity, agent, anim, player, stats, enemy);
                stage = EVENT.Exit;
            } else if(!CanSeePlayer())
            {
                nextState = new GranadierIdle(entity, agent, anim, player, stats, enemy);
                stage = EVENT.Exit;
            }

        }
    }
    public override void Exit()
    {
        agent.isStopped = true;
        anim.SetBool("InPursuit", false);
        base.Exit();
    }

}
