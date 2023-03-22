using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GranadierDie : State
{
    public GranadierDie(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats) : base(_entity, _agent, _anim, _player, _stats)
    {
    }
    public override void Enter()
    {
        agent.isStopped = true;
        entity.SetActive(false);
        base.Enter();
    }

    public override void Update()
    {
        
    }
}
