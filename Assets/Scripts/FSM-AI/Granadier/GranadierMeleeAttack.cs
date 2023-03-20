using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierMeleeAttack : State
{
    public GranadierMeleeAttack(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats) : base(_entity, _agent, _anim, _player, _stats)
    {

    }

    public override void Enter()
    {
        agent.isStopped = true;
        base.Enter();
    }

    public override void Update()
    {
        //Melee attack logic
        if (CanShootPlayer())
        {
            nextState = new GranadierRangeAttack(entity, agent, anim, player, stats);
            stage = EVENT.Exit;
        }
        else if (!CanMeleePlayer())
        {
            nextState = new GranadierIdle(entity, agent, anim, player, stats);
            stage = EVENT.Exit;
        }
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
