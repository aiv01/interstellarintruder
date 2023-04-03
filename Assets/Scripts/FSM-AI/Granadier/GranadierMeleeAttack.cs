using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierMeleeAttack : State
{
    public GranadierMeleeAttack(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats, EnemyAI _enemy) : base(_entity, _agent, _anim, _player, _stats, _enemy)
    {
        stateType = STATE.MeleeAttack;
    }

    public override void Enter()
    {
        agent.isStopped = true;
        base.Enter();
    }

    public override void Update()
    {
        anim.SetTrigger("MeleeAttack");
        //Melee attack logic
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
        if (CanShootPlayer())
        {
            nextState = new GranadierRangeAttack(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        }
        else if (!CanMeleePlayer())
        {
            nextState = new GranadierIdle(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        }
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
