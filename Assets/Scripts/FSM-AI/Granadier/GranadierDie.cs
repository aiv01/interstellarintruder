using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierDie : State
{
    public GranadierDie(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats, EnemyAI _enemy) : base(_entity, _agent, _anim, _player, _stats, _enemy)
    {
        stateType = STATE.Die;
    }
    public override void Enter()
    {
        agent.isStopped = true;
        anim.SetTrigger("Death");
        enemy.myTile.enemyCounter--;
        base.Enter();
    }

    public override void Update()
    {
         
    }

    public override void Exit()
    {
        base.Exit();
    }
}
