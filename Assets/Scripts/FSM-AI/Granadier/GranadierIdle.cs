using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierIdle : State
{
    public GranadierIdle(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats, EnemyAI _enemy) : base(_entity, _agent, _anim, _player, _stats, _enemy)
    {
        stateType = STATE.Idle;
    }

    public override void Enter()
    {
        anim.SetBool("InPursuit",false);
        base.Enter();
    }

    public override void Update()
    {
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
        if (CanSeePlayer())
        {
            nextState = new GranadierChase(entity,agent,anim,player,stats, enemy);
            stage = EVENT.Exit;
        } else if(Random.Range(0,100) < 10)
        {
            nextState = new GranadierPatrol(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
