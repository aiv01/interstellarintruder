using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierIdle : State
{
    public GranadierIdle(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats) : base(_entity, _agent, _anim, _player, _stats)
    {
        stateType = STATE.Idle;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("Idle");
        if (CanSeePlayer())
        {
            nextState = new GranadierChase(entity,agent,anim,player,stats);
            stage = EVENT.Exit;
        } else if(Random.Range(0,100) < 10)
        {
            nextState = new GranadierPatrol(entity, agent, anim, player, stats);
            stage = EVENT.Exit;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
