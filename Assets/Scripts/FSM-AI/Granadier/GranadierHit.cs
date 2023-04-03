using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierHit : State
{
    public GranadierHit(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats, EnemyAI _enemy) : base(_entity, _agent, _anim, _player, _stats, _enemy)
    {
        stateType = STATE.Hit;
    }

    public override void Enter()
    {
        anim.SetTrigger("Hit");
        base.Enter();
    }

    public override void Update()
    {
        enemy.Hitted = false;
        stage = EVENT.Exit;
    }
    public override void Exit()
    {
        nextState = new GranadierChase(entity, agent, anim, player, stats, enemy);
        
        base.Exit();
    }


}
